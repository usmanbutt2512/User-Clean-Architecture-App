using System.Diagnostics;

namespace UA.WebApi.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        //Logs the Http method, gets the time it took, response status code and path
        public async Task InvokeAsync (HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var method = context.Request.Method;
            var path = context.Request.Path;
            await _next(context);
            stopwatch.Stop();
            var status = context.Response.StatusCode;
            _logger.LogInformation("HTTP {Method} {Path} responded {Status} in {ElapsedMilliseconds}ms", method, path, status, stopwatch.ElapsedMilliseconds);
        }
    }
}
