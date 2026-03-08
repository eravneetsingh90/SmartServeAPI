using Microsoft.EntityFrameworkCore;
using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.EFCore.Db;

namespace SmartServe.Persistence.Stores
{
    public class TenantStore : ITenantStore
    {
        protected readonly SmartServeDbContext Db;

        public TenantStore(SmartServeDbContext db)
        {
            Db = db;
        }
        public async Task<Tenant?> GetTenantByCode(string tenantCode)
        {
            return await Db.Tenants
                .AsNoTracking()
                .FirstOrDefaultAsync(t =>
                    t.Subdomain == tenantCode &&
                    t.IsActive == true);
        }
    }
}
