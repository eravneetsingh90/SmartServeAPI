using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface ITableStatusStore : IBaseStore<TableStatusEntity,int>
	{
		Task<TableStatusEntity> GetTableStatusByCode(string code);
	}
}
