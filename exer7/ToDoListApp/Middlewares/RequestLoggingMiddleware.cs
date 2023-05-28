using System.Diagnostics;

public class RequestLoggingMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;
    public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory){
        _next = next;
        _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
    }
    public async Task InvokeAsync(HttpContext context){
        var stopWatch = Stopwatch.StartNew();
        try
        {
            await _next(context);
            stopWatch.Stop();
        }
        finally
        {
            _logger.LogInformation("Http {method} request for path {path} with status {status} executed in {duration} ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopWatch.ElapsedMilliseconds
            );
        }
    }

}