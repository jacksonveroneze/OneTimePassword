using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OneTimePassword.Api.Middlewares
{
    public class RequestLoggingMiddleware
    {
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(
                "Request: {method} - {protocol} - {url}",
                context.Request?.Method,
                context.Request?.Protocol,
                context.Request?.Path.Value);

            await _next(context);

            _logger.LogInformation(
                "Response: {statusCode}",
                context.Response?.StatusCode);
        }
    }
}
