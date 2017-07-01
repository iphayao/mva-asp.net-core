using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMvaWebApp.Middleware
{
    public class EnvironmentDisplay
    {
        private readonly IConfigurationRoot _config;
        private readonly IHostingEnvironment _env;
        private readonly RequestDelegate _next;


        public EnvironmentDisplay(RequestDelegate next, IHostingEnvironment env, IConfigurationRoot config)
        {
            _config = config;
            _env = env;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
