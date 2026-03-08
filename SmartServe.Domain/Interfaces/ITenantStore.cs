using SmartServe.Domain.Entities;
using SmartServe.Domain.Stores.SmartServe.Domain.Stores;

namespace SmartServe.Domain.Interfaces
{
    public interface ITenantStore
    {
        Task<Tenant?> GetTenantByCode(string tenantCode);
    }
}
