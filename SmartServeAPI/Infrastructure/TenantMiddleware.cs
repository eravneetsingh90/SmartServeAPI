namespace SmartServe.API.Infrastructure
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenant = context.Request.Headers["x-tenant"];

            context.Items["TenantId"] = tenant;

            await _next(context);
        }
    }
}
