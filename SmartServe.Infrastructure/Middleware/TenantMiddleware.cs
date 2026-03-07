using Microsoft.AspNetCore.Http;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Interfaces;

namespace SmartServe.Infrastructure.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        
        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantStore tenantStore)
        {
            if (!context.Request.Headers.TryGetValue("X-Tenant-Code", out var tenantCode))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Tenant code is required.");
                return;
            }

            var tenant = await tenantStore.GetTenantByCode(tenantCode);

            if (tenant == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid tenant.");
                return;
            }
            context.Items[ContextKeys.TenantId] = tenant.Id;
            context.Items[ContextKeys.TenantCode] = tenant.Subdomain;
            await _next(context);
        }
    }
}
