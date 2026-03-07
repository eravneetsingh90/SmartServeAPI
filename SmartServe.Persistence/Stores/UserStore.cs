using Microsoft.EntityFrameworkCore;
using SmartServe.Domain.Entities;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Db;

namespace SmartServe.Persistence.Stores
{
	public class UserStore : BaseStore<User, int>, IUserStore
	{
		public UserStore(SmartServeDbContext db)
			: base(db)
		{
		}

		public async Task<User?> GetActiveUserByUsernameAsync(string username,int tenantId)
		{
			var result = await Set
				.AsNoTracking()
				.Include(u=>u.Role)
                .Include(u => u.Tenant)
                .FirstOrDefaultAsync(u =>
					u.Username == username &&
					u.TenantId == tenantId &&
					u.IsActive == true);
			return result;
		}
	}
}
