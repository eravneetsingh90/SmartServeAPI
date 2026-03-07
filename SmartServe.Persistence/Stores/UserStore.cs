using Microsoft.EntityFrameworkCore;
using SmartServe.Domain.Entities;
using SmartServe.EFCore.Db;

namespace SmartServe.Domain.Stores
{
	public class UserStore : BaseStore<User, int>, IUserStore
	{
		public UserStore(SmartServeDbContext db)
			: base(db)
		{
		}

		public async Task<User?> GetActiveUserByUsernameAsync(string username)
		{
			var result = await Set
				.AsNoTracking()
				.Include(u=>u.Role)
				.FirstOrDefaultAsync(u =>
					u.Name == username &&
					u.IsActive == true);
			return result;
		}
	}
}
