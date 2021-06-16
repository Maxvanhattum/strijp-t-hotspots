using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Strijp_T_Hotspots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                Console.WriteLine(hostingContext.HostingEnvironment.EnvironmentName);
                IHostEnvironment env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", true, true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                config.AddEnvironmentVariables();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
