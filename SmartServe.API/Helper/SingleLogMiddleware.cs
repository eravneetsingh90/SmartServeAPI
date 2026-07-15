using SmartServe.Common.Models;
using SmartServe.Domain.Constants;

namespace SmartServe.API.Helper
{

    public class SingleLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SingleLogMiddleware> _logger;

        public SingleLogMiddleware(RequestDelegate next, ILogger<SingleLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var logContext = new RequestLogContext
            {
                Action = context.Request.Path
            };

            context.Items["RequestLog"] = logContext;

            try
            {
                await _next(context);

                logContext.StatusCode = context.Response.StatusCode;
                
                _logger.LogInformation(
                    "API Completed {@RequestLog}",
                    logContext);
            }
            catch (Exception ex)
            {
                logContext.ResultCode = ResultCodes.Error;
                logContext.ResultMessage = ResultMessages.Error;
                logContext.StatusCode = StatusCodes.Status500InternalServerError;
                logContext.Errors.Add(ex.Message);

                _logger.LogError(ex,
                    "API Failed {@RequestLog}",
                    logContext);

                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(new
                {
                    ResultCode = ResultCodes.Error,
                    ResultMessage = ResultMessages.Error
                });

                return;
            }
        }
    }
}
