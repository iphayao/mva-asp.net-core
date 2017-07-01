using SuperMvaWebApp.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseEnvironmentDisplay(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnvironmentDisplay>();
        }
    }
}
