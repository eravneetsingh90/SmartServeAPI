using SmartServe.API.Helper;
using SmartServe.API.Mapping;
using SmartServe.Domain.Dependencies;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Services;
using SmartServe.EFCore.Dependencies;

namespace SmartServe.API.Dependencies
{
    public static class DependencyExtensions
    {
        public static IServiceCollection UseApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUser, CurrentUser>();

            //mapping profiles
            services.AddAutoMapper(typeof(MappingProfile));
            services.UseDomain();
            services.UseEFCore(configuration);

            return services;
        }
    }
}
