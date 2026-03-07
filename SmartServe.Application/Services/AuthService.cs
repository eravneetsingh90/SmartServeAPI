using SmartServe.Application.Interfaces;
using SmartServe.Domain.Stores;

namespace SmartServe.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserStore _userStore;

        public AuthService(IUserStore userStore)
        {
            _userStore = userStore;
        }

        //public async Task<BaseResponse<LoginResponse>> LoginAsync(string username, string pin)
        //{
        //    var response = new BaseResponse<LoginResponse>();

        //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pin))
        //    {
        //        return WithMappedError(response, ResultCodes.DataValidationError, ResultMessages.DataValidationError);
        //    }
        //    else if (username.Equals("user") && pin.Equals("1234"))
        //    {
        //        var chefUser = new UserEntity
        //        {
        //            Name = username
        //        };
        //        response.Data = new LoginResponse
        //        {
        //            Name = chefUser.Name,
        //            Role = RoleType.CASHIER
        //        };
        //        return response;
        //    }
        //    var user = await _userStore.GetActiveUserByUsernameAsync(username);
        //    if (user == null)
        //        return WithMappedError(response, ResultCodes.LoginError, ResultMessages.LoginError);
        //    if (!PinHasher.Verify(pin, user.PinHash))
        //        return WithMappedError(response, ResultCodes.LoginError, ResultMessages.LoginError);
        //    response.Data = new LoginResponse
        //    {
        //        Name = user.Name,
        //        Role = user.Role.RoleName
        //    };
        //    return response;
        //}

        //private BaseResponse<T> WithMappedError<T>(BaseResponse<T> response, string resultCode, string? resultMessage)
        //{
        //    response.MetaData.ResultCode = resultCode;
        //    if (!string.IsNullOrWhiteSpace(resultMessage))
        //        response.MetaData.ResultMessage = resultMessage;
        //    return response;
        //}
    }
}
