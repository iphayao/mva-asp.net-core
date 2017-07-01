using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMvaWebMovies.middleware
{
    /// <summary>
    /// This ads a notification glyph to the corner of UI to indicate the environment we are running in.
    /// </summary>
    public class EnvironmentDisplay
    {
        private readonly IConfigurationRoot _Config;
        private readonly IHostingEnvironment _Env;
        private readonly RequestDelegate _Next;

        public EnvironmentDisplay(RequestDelegate next, IHostingEnvironment env, IConfigurationRoot config)
        {
            _Next = next;
            _Env = env;
            _Config = config;
        }

        public string EnvironmentName
        {
            get
            {
                return _Env.EnvironmentName;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _Config.GetValue <bool>("EnvironmentDisplay", false);
            }
        }

        public async Task Invoke(HttpContext context)
        {
            // Add the HTML for the gylph to the response
            var newHeadContent = AddHead();
            var newBodyContent = AddBody();

            var existingBody = context.Response.Body;

            using(var newBody = new MemoryStream())
            {
                context.Response.Body = newBody;

                await _Next(context);

                context.Response.Body = existingBody;

                if(!context.Response.ContentType.StartsWith("text/html"))
                {
                    await context.Response.WriteAsync(new StreamReader(newBody).ReadToEnd());
                    return;
                }
                newBody.Seek(0, SeekOrigin.Begin);

                var newContent = new StreamReader(newBody).ReadToEnd();
                newContent = newContent.Replace("</head>", newHeadContent + "</head>");
                newContent = newContent.Replace("</boday>", newBodyContent + "</body>");

                await context.Response.WriteAsync(newContent);
            }
        }

        private string AddHead()
        {
            return @"<style>.AspNetEnv { text-indent: 100%; white-space: nowrap; overflow: hidden; position: absolute };
                    .AspNetEnv_Development { background-image: url(images/development.png); }
                    .AspNetEnv_Staging { background-image: url(images/staging.png); }
                    .AspNetEnv_Production { background-image: url(images/production.png); }
                    </style>";
        }

        private string AddBody()
        {
            return $"<div id=\"AspNetEnvIndicator\" class\"AspNetEnv AspNetEnv_{_Env.EnvironmentName}\" />";
        }
    }
}
