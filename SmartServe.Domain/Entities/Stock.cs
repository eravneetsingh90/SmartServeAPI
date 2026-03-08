using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Stock : IEntity<int>, ITenantEntity
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string ItemType { get; set; } = null!;

    public int VariantId { get; set; }

    public string Unit { get; set; } = null!;

    public decimal? CurrentQuantity { get; set; }

    public decimal? MinStockLevel { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ProductVariant Variant { get; set; } = null!;
}
