using SmartServe.Application.Models;

namespace SmartServe.Application.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request);
    }
}
