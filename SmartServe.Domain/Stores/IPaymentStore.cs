using SmartServe.Domain.Stores.SmartServe.Domain.Stores;
using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Stores
{
	public interface IPaymentStore : IBaseStore<PaymentEntity,int>
	{
		Task AddPaymentsAsync(List<PaymentEntity> payments); 
		Task<List<PaymentEntity>> GetByDateFilterAsync(DateTime fromUtc, DateTime toUtc);
	}
}
