using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class ProductEntity : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? FoodType { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CategoryEntity? Category { get; set; }

    public virtual ICollection<ProductVariantEntity> ProductVariants { get; set; } = new List<ProductVariantEntity>();

    public virtual TenantEntity Tenant { get; set; } = null!;
}
