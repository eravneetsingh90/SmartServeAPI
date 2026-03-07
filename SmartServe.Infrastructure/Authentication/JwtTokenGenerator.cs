using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartServe.Application.Interfaces;
using SmartServe.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartServe.Infrastructure.Authentication
{
    public sealed class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _settings;

        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Username", user.Username),
            new Claim("Role", user.Role.RoleName),
            new Claim("TenantId", user.Tenant.Id.ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
