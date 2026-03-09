using SmartServe.API.Mapping;
using SmartServe.Domain.Dependencies;
using SmartServe.Persistence.Dependencies;
using SmartServe.Application.Dependencies;
using SmartServe.Infrastructure.Dependencies;

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
            services.AddInfrastructure();
            services.AddApplication();
            services.AddPersistence(configuration);
            services.AddDomain();

            return services;
        }
    }
}
