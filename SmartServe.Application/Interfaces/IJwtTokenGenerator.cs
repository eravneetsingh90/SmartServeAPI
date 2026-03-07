namespace SmartServe.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(
            Guid userId,
            string username,
            string role,
            Guid tenantId);
    }
}
