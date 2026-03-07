using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class ProductIngredientEntity : IEntity<int>
{
    public int Id { get; set; }
    public int TenantId { get; set; }

    public int ProductVariantId { get; set; }

    public int IngredientVariantId { get; set; }

    public decimal Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ProductVariantEntity IngredientVariant { get; set; } = null!;

    public virtual ProductVariantEntity ProductVariant { get; set; } = null!;

    public virtual TenantEntity Tenant { get; set; } = null!;
}
