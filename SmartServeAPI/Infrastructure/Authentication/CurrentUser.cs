using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SmartServe.API.Infrastructure.Authentication;

public interface ICurrentUser
{
    Guid? UserId { get; }

    string? Username { get; }

    string? Role { get; }

    Guid? TenantId { get; }

    bool IsAuthenticated { get; }
}

public sealed class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated =>
        User?.Identity?.IsAuthenticated ?? false;

    public Guid? UserId
    {
        get
        {
            var value = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(value, out var id) ? id : null;
        }
    }

    public string? Username =>
        User?.FindFirstValue(ClaimTypes.Name);

    public string? Role =>
        User?.FindFirstValue(ClaimTypes.Role);

    public Guid? TenantId
    {
        get
        {
            var value = User?.FindFirstValue("TenantId");
            return Guid.TryParse(value, out var id) ? id : null;
        }
    }
}