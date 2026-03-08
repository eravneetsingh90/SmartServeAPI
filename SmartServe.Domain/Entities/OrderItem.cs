using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class OrderItem : IEntity<int>, ITenantEntity
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

    public virtual Order? Order { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ProductVariant? Variant { get; set; }
}
