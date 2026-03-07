using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Models;
using SmartServe.Application.Interfaces;
using SmartServe.Application.Models;
using SmartServe.Domain.Constants;

namespace SmartServe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    
    public AuthController(
        IMapper mapper, 
        IAuthService authService,
        IJwtTokenGenerator jwtTokenGenerator,
        ILogger<AuthController> logger)
    {
        _mapper = mapper;
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BaseResponse<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        
        var response = await _authService.LoginAsync(_mapper.Map<LoginRequest>(request));

        if (response.MetaData.ResultCode != ResultCodes.Success)
        {
            return Unauthorized(new
            {
                message = "Invalid username or password"
            });
        }

        return Ok(response);
    }
}