using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Models;
using SmartServe.Application.Models;

namespace SmartServe.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseResponseDto<T> WithMappedError<T>(
            BaseResponseDto<T> response,
            string resultCode,
            string? resultMessage)
        {
            response.MetaData.ResultCode = resultCode;

            if (!string.IsNullOrWhiteSpace(resultMessage))
                response.MetaData.ResultMessage = resultMessage;

            return response;
        }

        
    }
}