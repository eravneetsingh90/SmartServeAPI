namespace SmartServe.Domain.Interfaces
{
    public interface ICurrentUser
    {
        int? UserId { get; }

        string? Username { get; }

        string? Role { get; }

        int? TenantId { get; }

        string? TenantCode { get; }
    }
}
