using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.Text;
using WebAPI1.Model;
using WebAPI1.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;    //versão 3.0
using Microsoft.IdentityModel.Tokens;

namespace WebAPI1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //JWT
            //Definir o protocolo de Autenticação
            var tokenKey = Configuration["Jwt:Key"];        //definida em appsettings.json
            var key = Encoding.ASCII.GetBytes(tokenKey);    //codifica string

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //2º - Configurar JwtBearer - Valida JWT recebido no Header
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    //options.Audience = "https://localhost:44348/";
                    //options.Authority = "https://localhost:44348/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            //Registar a classe que gere JWT   
            services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));

            //ou
            //Swashbuckle 
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1-2023",
                    Title = "ISI API",
                    Description = "ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.ipca.pt/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Lufer",
                        Email = string.Empty,
                        Url = new Uri("http://www.ipca.pt"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Copyright",
                        Url = new Uri("http://www.ipca.pt/license"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http, //não usa o Bearer
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseRouting();

            //JWT
            app.UseAuthentication();
            app.UseAuthorization();     //Roles

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
