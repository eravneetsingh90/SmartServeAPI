using Microsoft.EntityFrameworkCore;
using SmartServe.EFCore.Db;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public class TableStatusStore : BaseStore<TableStatusEntity,int>, ITableStatusStore
	{
		public TableStatusStore(SmartServeDbContext db) : base(db) { }

		public async Task<TableStatusEntity?>  GetTableStatusByCode(string code)
		{
			return await Set.Where(ts => ts.StatusCode == code).FirstOrDefaultAsync();
		}
	}
}
