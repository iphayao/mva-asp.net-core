using SuperMvaWebMovies.middleware;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// This is utility container class that provides the simple "Use" systex for the middleware in this project
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseEnvironmentDisplay(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnvironmentDisplay>();
        }
    }
}
