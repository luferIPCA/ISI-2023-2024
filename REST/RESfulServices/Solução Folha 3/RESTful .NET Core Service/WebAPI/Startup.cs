/*
*	<copyright file="Startup.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>lufer</author>
*   <date>12/10/2023 10:34:15 AM</date>
*	<description></description>
**/


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;

namespace WebAPI
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
            //h1: services.AddSwaggerGen();
            //h2:
            //Configurar o OpenAPI
            services.AddSwaggerDocument(o =>
            o.PostProcess = document =>
            {
                document.Info.Title = "Core API";
                document.Info.Version = "v1";
                document.Info.Description = "A simple ASP.NET Core web API";
                document.Info.Contact = new NSwag.OpenApiContact    //está a ser usado o gestor NSwag
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
            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
