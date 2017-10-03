using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EfCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        //new WebHostBuilder()
        //.UseKestrel()
        //.UseContentRoot(Directory.GetCurrentDirectory())
        //.UseIISIntegration()
        //.UseDefaultServiceProvider(opt => opt.ValidateScopes = false)
        //.UseStartup<Startup>()
        //.Build();

        WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
    }
}
