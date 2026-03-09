using SmartServe.Domain.Entities;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;

namespace SmartServe.Domain.Interfaces
{
    public interface ICategoryStore : IBaseStore<Category, int>
    {
        Task SaveBulkAsync(IEnumerable<Category> categories);
    }
}
