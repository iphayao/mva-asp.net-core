using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SuperMvaOnMac
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app) 
        {
            app.Run(
                context => {
                    return context.Response.WriteAsync("Hello World!");
                } 
            );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                        .UseKestrel()
                        .UseStartup<Startup>()
                        .Build();
            host.Run();
        }
    }
}
