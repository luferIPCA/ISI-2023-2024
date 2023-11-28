/*
 * lufer
 * ISI
 * OAuth
 * See https://dotnetcorecentral.com/blog/authentication-handler-in-asp-net-core/
 * */
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using RESTAuth.Controllers;
using System;
using System.Linq;
using System.Text;

namespace RESTAuth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Definir o protocolo de Autenticação
            var tokenKey = Configuration["Jwt:Key"];        //definida em appsettings.json
            var key = Encoding.ASCII.GetBytes(tokenKey);    //codifica string

            //Authentication
            //Autentication Request: Middleware para Autenticação
            //services.AddAuthentication(x =>
            //{
            //    //1º - Esquemas de Autenticação e "Challenge" a usar - JwtBearer
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
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
            //Caso interesse partir apenas dos dados que estão no appsetttings.json para definir o JWT           
            services.AddSingleton<IConfiguration>(Configuration);
      
            //Roles
            //Authorization Request: Middleware para Autorização
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Autorizado", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AuthorizedRequirement());
                });
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });
            //Registar o gestor de Autorizações
            services.AddSingleton<IAuthorizationHandler, AuthorizedRequirementHandler>();

            //Configurar o OpenAPI com NSwag
            services.AddSwaggerDocument(o =>
            {
                o.DocumentName = "lufer_v1";

                //Adiciona o token "Authorize"
                o.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                o.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new NSwag.OpenApiSecurityScheme()
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the value field: Bearer {token}"
                    });

                //Configura Header
                o.PostProcess = document =>              
                {
                   document.Info.Title = "Core API com JWT - by lufer";
                   document.Info.Version = "v1";
                   document.Info.Description = "A simple ASP.NET Core web API with OAuth com JWT";
                   document.Info.Contact = new NSwag.OpenApiContact()   //está a ser usado o gestor NSwag              
                    {
                       Name = "Lufer",
                       Email = "lufer@ipca.pt",
                       Url = "https://www.ipca.pt"
                   };
                   document.Info.License = new NSwag.OpenApiLicense
                   {
                       Name = "Use under IPCA rights",
                       Url = "https://www.ipca.pt/license"
                   };             
                };
            }); //AddSwaggerDocument
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();            //Nuget Package"NSwag.AspNetCore

            app.UseRouting();

            app.UseAuthentication();        //para usar "login" e gerar o JWT
            app.UseAuthorization();         //caso interesse controlar autorização...com Roles...não está a ser considerado!

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
  
        }
    }

}

