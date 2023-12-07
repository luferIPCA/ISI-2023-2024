/*
 * lufer
 * ISI
 * OAuth
 * */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Authentication.Google;

namespace GoogleAuth
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

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoogleAuth", Version = "v1" });
            //});


            //services.AddIdentity<IdentityUser, IdentityRole>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                options.ClientId = ""; // 924524718640-c3qv6kil38letngh09bl1dd8ihajeh5a.apps.googleusercontent.com";
                options.ClientSecret = "";// "l78Zu3j1Aulckjv1ARMEC4xb";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoogleAuth v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            //
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
