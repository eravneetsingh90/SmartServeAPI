using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Infrastructure;
using SmartServe.API.Infrastructure.Authentication;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Services;

namespace SmartServe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IAuthService authService,
        IJwtTokenGenerator jwtTokenGenerator,
        ILogger<AuthController> logger)
    {
        _authService = authService;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Login([FromBody] LoginRequestDto request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        //var response = await _authService.LoginAsync(request.Username, request.Pin);

        //if (response.MetaData.ResultCode != ResultCodes.Success)
        //{
        //    _logger.LogWarning("Invalid login attempt for {Username}", request.Username);
        //    return Unauthorized(new
        //    {
        //        message = "Invalid username or password"
        //    });
        //}

        //var token = _jwtTokenGenerator.GenerateToken(user);
        //    var token = _jwtTokenGenerator.GenerateToken(
        //user.Id,
        //user.Username,
        //user.Role,
        //user.TenantId);
        //var token = _jwtTokenGenerator.GenerateToken(
        //new Guid(),
        //response.Data.Name,
        //response.Data.Role,
        //new Guid());
        //_logger.LogInformation("User {UserId} logged in successfully", response.Data.Name);

        //return Ok(new AuthResponseDto
        //{
        //    AccessToken = token,
        //    ExpiresInMinutes = 60 // optionally fetch from JwtSettings
        //});
        return Ok();
    }
}