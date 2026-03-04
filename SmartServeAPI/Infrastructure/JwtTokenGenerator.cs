using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartServe.API.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartServe.API.Infrastructure;

public interface IJwtTokenGenerator
{
    //string GenerateToken(User user);
    string GenerateToken();
}

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _settings;

    public JwtTokenGenerator(IOptions<JwtSettings> options)
    {
        _settings = options.Value;
    }
    public string GenerateToken()
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_settings.Key));

        var creds = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            //claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    //public string GenerateToken(User user)
    //{
    //    var claims = new List<Claim>
    //    {
    //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //        new Claim(ClaimTypes.Name, user.Username),
    //        new Claim(ClaimTypes.Role, user.Role),
    //        new Claim("TenantId", user.TenantId.ToString())
    //    };

    //    var key = new SymmetricSecurityKey(
    //        Encoding.UTF8.GetBytes(_settings.Key));

    //    var creds = new SigningCredentials(
    //        key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        issuer: _settings.Issuer,
    //        audience: _settings.Audience,
    //        claims: claims,
    //        expires: DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes),
    //        signingCredentials: creds);

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}
}