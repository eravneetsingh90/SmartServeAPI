using SmartServe.Domain.Models;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IOrderStore : IBaseStore<OrderEntity,int>
	{
		Task<OrderEntity?> GetOrderAsync(int orderId);
		//void Update(OrderEntity order);
		Task<OrderEntity?> GetByOrderNumberAsync(string orderNumber);
		Task<List<OrderEntity>> GetByDateFilterAsync(DateTime fromUtc, DateTime toUtc);
		Task<List<OrderEntity>> GetUntrackedOrdersAsync(int max, CancellationToken ct);
	}

}
