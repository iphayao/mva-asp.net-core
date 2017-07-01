using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SuperMvaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMvaWebApp.Middleware
{
    public class RequestIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestIdMiddleware> _logger;

        public RequestIdMiddleware(RequestDelegate next, IRequestId requestId, ILogger<RequestIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext context, IRequestId requestId)
        {
            _logger.LogInformation($"Reqeust {requestId.Id} executing.");
            return _next(context);
        }
    }
}
