using SmartServe.Domain.Entities;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;

namespace SmartServe.Domain.Interfaces
{
    public interface IProductStore : IBaseStore<Product, int>
    {
        Task SaveBulkAsync(IEnumerable<Product> products);
    }
}
