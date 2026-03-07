using Microsoft.Extensions.DependencyInjection;
using SmartServe.Application.Interfaces;
using SmartServe.Application.Services;

namespace SmartServe.Application.Dependencies
{
    public static class DependencyExtensions
    {
        public static IServiceCollection UseApplication(
            this IServiceCollection services)
        {
            //services
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
