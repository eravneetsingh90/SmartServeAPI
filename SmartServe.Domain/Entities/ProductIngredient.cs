using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class ProductIngredient : IEntity<int>, ITenantEntity
{
    public int Id { get; set; }
    public int TenantId { get; set; }

    public int ProductVariantId { get; set; }

    public int IngredientVariantId { get; set; }

    public decimal Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ProductVariant IngredientVariant { get; set; } = null!;

    public virtual ProductVariant ProductVariant { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
