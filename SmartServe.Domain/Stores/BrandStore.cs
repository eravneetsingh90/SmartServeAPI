using SmartServe.EFCore.Db;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public class BrandStore: BaseStore<BrandEntity,int>,IBrandStore
	{
		public BrandStore(SmartServeDbContext db) : base(db)
		{
		}
	}
}
