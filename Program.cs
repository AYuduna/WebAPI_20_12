using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //using (var scope = new Scope<IServiceProvider>
            //{
              //  var service
                //}
            host.Run();
        }




        public static IHostBuilder CreateHostBuilder(string[] args) =>
        //Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //    });
        Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>();
             webBuilder.UseUrls(
             "http://localhost:5001"
             );
         });
    }
}
