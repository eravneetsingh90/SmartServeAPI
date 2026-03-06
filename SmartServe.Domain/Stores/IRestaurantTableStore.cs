using SmartServe.Domain.Models;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IRestaurantTableStore : IBaseStore<RestaurantTableEntity, int>
	{
		Task<List<RestaurantTable>> GetActiveRestaurantTablesAsync();
		Task CreateTableAsync(string displayName);
		Task<List<GetTableView>> GetTablesForViewAsync();
	}
}
