using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common;

namespace PractiZing.Api.DenailManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = new UrlConfiguration().GetAppUrl();

            BuildWebHost(url, args).Run();
        }


        public static IWebHost BuildWebHost(string url, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Limits.MaxRequestBodySize = null;
                })
                .UseUrls(url)
                .Build();
    }
}
