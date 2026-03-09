using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Db;

namespace SmartServe.Persistence.Stores
{
    public class CategoryStore : BaseStore<Category, int>, ICategoryStore
    {
        private readonly IUnitOfWork _uow;

        public CategoryStore(SmartServeDbContext db, IUnitOfWork uow)
            : base(db)
        {
            _uow = uow;
        }

        public async Task SaveBulkAsync(IEnumerable<Category> categories)
        {
            await _uow.BeginAsync();

            try
            {
                foreach (var category in categories)
                {
                    if (category.Id == 0)
                        Add(category);
                    else
                    {
                        var tracked = Db.Categories.Local
                            .FirstOrDefault(x => x.Id == category.Id);

                        if (tracked == null)
                        {
                            tracked = new Category
                            {
                                Id = category.Id
                            };

                            Attach(tracked);
                        }
                        Db.Entry(tracked).CurrentValues.SetValues(category);
                    }
                }

                await _uow.CommitAsync();
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }

    }
}
