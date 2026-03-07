using SmartServe.Domain.Entities;

namespace SmartServe.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
