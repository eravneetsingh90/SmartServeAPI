using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.EFCore.Db;

namespace SmartServe.Persistence.Stores
{
    public class CategoryStore : BaseStore<Category, int>, ICategoryStore
    {
        public CategoryStore(SmartServeDbContext db)
            : base(db)
        {
        }

    }
}
