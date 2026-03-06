using Microsoft.EntityFrameworkCore;
using SmartServe.EFCore.Db;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public class ProductIngredientStore : BaseStore<ProductIngredientEntity,int>, IProductIngredientStore
	{
		public ProductIngredientStore(SmartServeDbContext db) : base(db)
		{
		}


	}
}
