using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
/*
 *
 */
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;     //1º - Incluir para usar OpenAPI
using System;

namespace OutroRestfull
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //2º - Para usar swagger
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApi-ISI",
                    Version = "v1.0",
                    Description = "Exemplo Web Api com documentação OpenAPI",
                    Contact = new OpenApiContact
                    {
                        Name = "Integração de Sistemas de Informação 2023/24",
                        Email = string.Empty,
                        Url = new Uri("https://elearning1.ipca.pt/2023"),
                    },
                });

                var filePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, "OutroRestfull.xml");
                c.IncludeXmlComments(filePath);

            });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //3º - Para usar swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
