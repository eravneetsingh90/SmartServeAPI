using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface ICategoryStore : IBaseStore<CategoryEntity,int>
	{
		Task<List<CategoryEntity>> GetActiveAsync();
		Task<List<CategoryEntity>> GetAllAsync();
		Task SaveBulkAsync(IEnumerable<CategoryEntity> categories);
		Task DeleteAsync(int id);
	}
}
