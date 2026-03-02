using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Services;

namespace SmartServe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    //[HttpPost("login")]
    //public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    //{
    //    var response = await _authService.LoginAsync(request.Username, request.Pin);

    //    if (response.MetaData.ResultCode != ResultCodes.Success)
    //        return Unauthorized(response);

    //    return Ok(response);
    //}
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        var response = await _authService.LoginAsync(request.Username, request.Pin);

        if (response.MetaData.ResultCode != ResultCodes.Success)
            return Unauthorized(response);

        return Ok(response);
    }
}