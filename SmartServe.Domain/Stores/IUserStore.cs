using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IUserStore : IBaseStore<UserEntity,int>
	{
		Task<UserEntity?> GetActiveUserByUsernameAsync(string username);
	}
}
