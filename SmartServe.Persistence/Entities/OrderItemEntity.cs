using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class OrderItemEntity : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public int? OrderId { get; set; }

    public int? VariantId { get; set; }

    public string? ProductNameSnapshot { get; set; }

    public string? VariantNameSnapshot { get; set; }

    public int Quantity { get; set; }

    public decimal PriceSnapshot { get; set; }

    public decimal? DiscountAmount { get; set; }

    public virtual OrderEntity? Order { get; set; }

    public virtual TenantEntity Tenant { get; set; } = null!;

    public virtual ProductVariantEntity? Variant { get; set; }
}
