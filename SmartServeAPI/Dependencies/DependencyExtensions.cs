using SmartServe.API.Infrastructure.Authentication;
using SmartServe.API.Mapping;
using SmartServe.Domain.Dependencies;
using SmartServe.Persistence.Dependencies;
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
            services.AddPersistence(configuration);
            services.UseDomain();

            return services;
        }
    }
}
