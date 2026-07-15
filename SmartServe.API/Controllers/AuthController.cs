using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Helper;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Models;

namespace SmartServe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
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
    public async Task<ActionResult<BaseResponseDto<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        
        var response = await _authService.LoginAsync(_mapper.Map<LoginRequest>(request));

        HttpContext.CreateAnnotation(Annotations.ResultCode, response.MetaData.ResultCode);
        HttpContext.CreateAnnotation(Annotations.ResultMessage, response.MetaData.ResultMessage);
        
        if (response.MetaData.ResultCode != ResultCodes.Success)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}