namespace API01.Middlewares
{
    public class RequestCountMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        private int _counter =0;

        public RequestCountMiddleware(RequestDelegate next, ILogger<RequestCountMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _counter++;
            _logger.LogInformation($"Request Count = {_counter}");
            await _next(context);
        }

      
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCounter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCountMiddleware>();
        }
    }
}
