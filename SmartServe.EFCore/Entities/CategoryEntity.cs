using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class CategoryEntity : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    public virtual TenantEntity Tenant { get; set; } = null!;
}
