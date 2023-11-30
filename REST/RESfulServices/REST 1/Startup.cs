using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST11
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //1º
            services.AddControllers();

            //3º - Para suportar XML
            services.AddControllers().AddXmlSerializerFormatters();
            //ou
            //services.AddControllers().AddXmlDataContractSerializerFormatters();

            #region SWAGGER
            // Nswag 

            //por omissão:
            //services.AddSwaggerDocument();

            //ou costumizar

            services.AddSwaggerDocument(o =>
                o.PostProcess = document =>
                {
                    document.Info.Title = "Core API";
                    document.Info.Version = "v1 2023";
                    document.Info.Description = "API de RESTful Services for ISI";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "ISI",
                        Email = "isi@ipca.pt",
                        Url = "https://www.ipca.pt"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under IPCA rights",
                        Url = "https://www.ipca.pt/license"
                    };
                }
                );

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //2º
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });

            #region SWAGGER
            
            if (env.IsDevelopment())
            {
                //3º - Para usar swagger
                app.UseOpenApi();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi 2023-2024 v1"));

            }
            #endregion

        }
    }
}
