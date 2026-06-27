using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Db;
using SmartServe.Persistence.Stores;
namespace SmartServe.Persistence.Dependencies

{
	public static class DependencyExtensions
	{
		public static IServiceCollection AddPersistence(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<SmartServeDbContext>(options =>
			{
				options.UseNpgsql(
					configuration.GetConnectionString("SmartServeDb")
				);
			});
            
			//stores
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUserStore, UserStore>();
            services.AddScoped<ITenantStore, TenantStore>();
            services.AddScoped<ICategoryStore, CategoryStore>();
            services.AddScoped<IProductStore, ProductStore>();

            return services;
		}
	}
}
