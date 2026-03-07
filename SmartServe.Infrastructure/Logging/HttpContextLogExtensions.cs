using Microsoft.AspNetCore.Http;
using SmartServe.Application.Models;
using SmartServe.Domain.Constants;
using System.Reflection.Metadata;

namespace SmartServe.Infrastructure.Logging
{
    public static class HttpContextLogExtensions
    {
        public static void CreateAnnotation(this HttpContext context, string key, object value)
        {
            if (!context.Items.TryGetValue("RequestLog", out var logObj))
                return;

            if (logObj is not RequestLogContext logContext)
                return;

            switch (key)
            {
                case Annotations.ResultCode:
                    logContext.ResultCode = value?.ToString();
                    break;

                case Annotations.ResultMessage:
                    logContext.ResultMessage = value?.ToString();
                    break;

                case Annotations.UserId:
                    logContext.UserId = Convert.ToInt32(value);
                    break;

                case Annotations.TenantCode:
                    logContext.TenantCode = Convert.ToString(value);
                    break;
            }
        }

        public static void SetResult(this HttpContext context, string resultCode, string message)
        {
            context.CreateAnnotation("ResultCode", resultCode);
            context.CreateAnnotation("ResultMessage", message);
        }
    }
}