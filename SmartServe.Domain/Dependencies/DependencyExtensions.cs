using Microsoft.Extensions.DependencyInjection;
using SmartServe.Domain.Mapping;
using SmartServe.Domain.Services;
using SmartServe.Domain.Stores;

namespace SmartServe.Domain.Dependencies
{
	public static class DependencyExtensions
	{
		public static IServiceCollection UseDomain(
			this IServiceCollection services)
		{
			//mapping profiles
			services.AddAutoMapper(typeof(MappingProfile));
            //services
            services.AddScoped<IAuthService, AuthService>();
            
			return services;
		}
	}
}


