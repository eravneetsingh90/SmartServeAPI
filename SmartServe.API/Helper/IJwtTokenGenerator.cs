using SmartServe.EFCore.Models;

namespace SmartServe.API.Helper
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserEntity user);
    }
}
