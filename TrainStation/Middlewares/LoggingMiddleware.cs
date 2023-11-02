using Microsoft.AspNetCore.Http.Extensions;
using TrainStation.Controllers;

namespace TrainStation.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<EmailController> logger)
        {
            _logger = logger;
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var requestUrl = httpContext.Request.GetDisplayUrl();
            var requestIpAddress = httpContext.Connection.RemoteIpAddress?.ToString();

            _logger.LogInformation("Request url: {requestUrl}, " +
                "IP address: {requestIpAddress}",
                requestUrl,
                requestIpAddress);

            return _next(httpContext);
        }
    }

    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
