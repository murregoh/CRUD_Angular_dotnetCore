using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetUpConfiguration)
                .UseStartup<Startup>();

        private static void SetUpConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Removing the default configuration options
            builder.Sources.Clear();


            builder.AddJsonFile("appsettings.json", false, true)
                    .AddEnvironmentVariables();
        }
    }
}
