using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IStockTransactionStore : IBaseStore<StockTransactionEntity, int>
	{

	}
}
