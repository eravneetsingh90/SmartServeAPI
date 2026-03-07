namespace SmartServe.Application.Interfaces
{
    public interface ICurrentUser
    {
        Guid? UserId { get; }

        string? Username { get; }

        string? Role { get; }

        Guid? TenantId { get; }

        bool IsAuthenticated { get; }
    }
}
