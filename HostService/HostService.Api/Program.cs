using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common;
using System.IO;

namespace HostService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = new UrlConfiguration().GetAppUrl();
            var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
        .Build();
            BuildWebHost(url, configuration, args).Run();
            
        }

        public static IWebHost BuildWebHost(string url, IConfiguration configuration, string[] args) =>
             WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(configuration)
              .ConfigureLogging((hostingContext, logging) =>
              {
                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 logging.AddConsole();
                 logging.AddDebug();
              })
              .UseKestrel(options =>
              {
                  options.AddServerHeader = false;
                  options.Limits.MaxRequestBodySize = null;
              })
              .UseUrls(url)
            .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
              .Build();
    }
}
