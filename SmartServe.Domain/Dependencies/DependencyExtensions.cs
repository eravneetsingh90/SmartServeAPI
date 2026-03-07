using Microsoft.Extensions.DependencyInjection;
using SmartServe.Domain.Mapping;

namespace SmartServe.Domain.Dependencies
{
	public static class DependencyExtensions
	{
		public static IServiceCollection AddDomain(
			this IServiceCollection services)
		{
			//mapping profiles
			services.AddAutoMapper(typeof(MappingProfile));
			return services;
		}
	}
}


