using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.LayoutRenderers;
using NLog.Web;
using SCG.CHEM.MBR.TRANSACTION.API.Logger;
using System;

namespace SCG.CHEM.MBR.TRANSACTION.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLogRegiter();
            var a = Environment.GetEnvironmentVariable("APP_ENV");
            CreateHostBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                     if (hostingContext.HostingEnvironment.IsProduction())
                     {
                         config.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
                     }
                     else if (Environment.GetEnvironmentVariable("APP_ENV").Equals("DEV"))
                     {
                         config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
                     }
                     else if (Environment.GetEnvironmentVariable("APP_ENV").Equals("QAS"))
                     {
                         config.AddJsonFile("appsettings.Qas.json", optional: false, reloadOnChange: true);
                     }
                     else if (Environment.GetEnvironmentVariable("APP_ENV").Equals("PRD"))
                     {
                         config.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
                     }
                 })
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                })
                .UseNLog();

        private static void NLogRegiter()
        {
            LayoutRenderer.Register<LocalDateLayoutRenderer>("localdate");
        }
    }
}