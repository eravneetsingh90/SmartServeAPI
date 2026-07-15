using Microsoft.AspNetCore.Http;
using SmartServe.Domain.Interfaces;
using System.Security.Claims;

namespace SmartServe.API.Helper
{

    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public int? UserId
        {
            get
            {
                var userId = User?.FindFirst("userId")?.Value;

                if (int.TryParse(userId, out var id))
                    return id;

                return null;
            }
        }

        public string? Username =>
            User?.FindFirstValue(ClaimTypes.Name);

        public string? Role =>
            User?.FindFirstValue(ClaimTypes.Role);

        public int? TenantId
        {
            get
            {
                var value = _httpContextAccessor.HttpContext?.Items["TenantId"];

                if (value == null)
                    return null;

                return (int)value;
            }
        }

        public string? TenantCode
        {
            get
            {
                return _httpContextAccessor.HttpContext?.Items["TenantCode"]?.ToString();
            }
        }
    }
}
