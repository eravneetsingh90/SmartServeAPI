using SmartServe.Domain.Entities;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;

namespace SmartServe.Domain.Stores
{
	public interface IUserStore : IBaseStore<User,int>
	{
		Task<User?> GetActiveUserByUsernameAsync(string username);
	}
}
