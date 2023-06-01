using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.LayoutRenderers;
using NLog.Web;
using SCG.CHEM.MBR.AUTH.API.Logger;
using System;

namespace SCG.CHEM.MBR.AUTH.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLogRegiter();
            CreateHostBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                     if (hostingContext.HostingEnvironment.IsProduction())
                     {
                         config.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
                     }
                     else if (Environment.MachineName.StartsWith("CPX-"))
                     {
                         config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
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
