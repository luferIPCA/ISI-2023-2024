/*
*	<copyright file="Program.cs" company="IPCA">
*		Copyright (c) 2023 All Rights Reserved
*	</copyright>
*	WebAPI RESTfful Services in ASP.NET Core
* 	<author>lufer</author>
*   <date>15/10/2023 10:34:15 AM</date>
*	<description></description>
**/

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
