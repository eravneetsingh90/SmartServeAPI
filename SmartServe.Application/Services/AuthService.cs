using SmartServe.Application.Helper;
using SmartServe.Application.Interfaces;
using SmartServe.Application.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Stores;

namespace SmartServe.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserStore _userStore;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserStore userStore, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userStore = userStore;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var response = new BaseResponse<LoginResponse>();

            if (string.IsNullOrWhiteSpace(request.Username) || (string.IsNullOrWhiteSpace(request.Password) && string.IsNullOrWhiteSpace(request.Pin)))
            {
                return WithMappedError(response, ResultCodes.DataValidationError, ResultMessages.DataValidationError);
            }
            var user = await _userStore.GetActiveUserByUsernameAsync(request.Username);
            if (user == null)
                return WithMappedError(response, ResultCodes.LoginError, ResultMessages.LoginError);
            else if (!string.IsNullOrWhiteSpace(request.Pin) && !PinHasher.Verify(request.Pin, user.PinHash))
                return WithMappedError(response, ResultCodes.LoginError, ResultMessages.LoginError);
            else if (!string.IsNullOrWhiteSpace(request.Password) && !PinHasher.Verify(request.Password, user.PasswordHash))
                return WithMappedError(response, ResultCodes.LoginError, ResultMessages.LoginError);

            var token = _jwtTokenGenerator.GenerateToken(user);

            response.Data = new LoginResponse
            {
                AccessToken = token,
                Username = user.Username,
                Role = user.Role.RoleName,
                ExpiresAt = DateTime.UtcNow.AddHours(2)
            };
            return response;
        }

        private BaseResponse<T> WithMappedError<T>(BaseResponse<T> response, string resultCode, string? resultMessage)
        {
            response.MetaData.ResultCode = resultCode;
            if (!string.IsNullOrWhiteSpace(resultMessage))
                response.MetaData.ResultMessage = resultMessage;
            return response;
        }
    }
}
