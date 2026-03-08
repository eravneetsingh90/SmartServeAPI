using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class ProductVariant : IEntity<int>, ITenantEntity
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public int ProductId { get; set; }

    public int? BrandId { get; set; }

    public string VariantName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductIngredient> ProductIngredientIngredientVariants { get; set; } = new List<ProductIngredient>();

    public virtual ICollection<ProductIngredient> ProductIngredientProductVariants { get; set; } = new List<ProductIngredient>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Tenant Tenant { get; set; } = null!;
}
