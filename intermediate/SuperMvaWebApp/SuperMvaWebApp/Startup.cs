using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SuperMvaWebApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json")
                                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(subApp =>
                {
                    subApp.Run(async context =>
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync("<strong>Application Error in Production. Context Support</strong>");
                        await context.Response.WriteAsync(new string(' ', 512));
                    });
                });
            }

            app.UseStatusCodePages(subApp =>
            {
                subApp.Run(async context =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<strong>NOT FOUND!</strong>");
                    await context.Response.WriteAsync(new string(' ', 512));
                });
            });

            app.UseEnvironmentDisplay();

            /*app.Run(context =>
            {
                context.Response.StatusCode = 404;
                return Task.FromResult(0);
            });

            app.Run(context =>
            {
                throw new InvalidOperationException("Did I do that? - Phayao!");
            });*/

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                            name: "default", 
                            template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
