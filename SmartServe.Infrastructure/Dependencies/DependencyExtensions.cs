using Microsoft.Extensions.DependencyInjection;
using SmartServe.Application.Interfaces;
using SmartServe.Domain.Interfaces;
using SmartServe.Infrastructure.Authentication;

namespace SmartServe.Infrastructure.Dependencies
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
