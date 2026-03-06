using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IProductStore : IBaseStore<ProductEntity, int>
	{
		Task<List<ProductEntity>> GetByCategoryIdAsync(int categoryId);
		Task SaveBulkAsync(IEnumerable<ProductEntity> products);
		Task DeleteAsync(int id);
	}
}
