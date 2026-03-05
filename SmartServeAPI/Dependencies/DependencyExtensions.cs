using SmartServe.API.Infrastructure;
using SmartServe.API.Infrastructure.Authentication;
using SmartServe.API.Mapping;
using SmartServe.Domain.Dependencies;
using SmartServe.EFCore.Dependencies;
namespace SmartServe.API.Dependencies
{
    public static class DependencyExtensions
    {
        public static IServiceCollection UseApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //mapping profiles
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.UseEFCore(configuration);
            services.UseDomain();

            return services;
        }
    }
}
