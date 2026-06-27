using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Db;

namespace SmartServe.Persistence.Stores
{
    public class ProductStore : BaseStore<Product, int>, IProductStore
    {
        private readonly IUnitOfWork _uow;

        public ProductStore(SmartServeDbContext db, IUnitOfWork uow)
            : base(db)
        {
            _uow = uow;
        }

        public async Task SaveBulkAsync(IEnumerable<Product> products)
        {
            await _uow.BeginAsync();

            try
            {
                foreach (var product in products)
                {
                    if (product.Id == 0)
                        Add(product);
                    else
                    {
                        var tracked = Db.Products.Local
                            .FirstOrDefault(x => x.Id == product.Id);

                        if (tracked == null)
                        {
                            tracked = new Product
                            {
                                Id = product.Id
                            };

                            Attach(tracked);
                        }
                        Db.Entry(tracked).CurrentValues.SetValues(product);
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