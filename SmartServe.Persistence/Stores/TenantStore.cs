using Microsoft.EntityFrameworkCore;
using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartServe.Persistence.Stores
{
    public class TenantStore : BaseStore<Tenant, int>, ITenantStore
    {
        public TenantStore(SmartServeDbContext db)
            : base(db)
        {
        }
        public async Task<Tenant?> GetTenantByCode(string tenantCode)
        {
            return await Set
                .AsNoTracking()
                .FirstOrDefaultAsync(t =>
                    t.Subdomain == tenantCode &&
                    t.IsActive == true);
        }
    }
}
