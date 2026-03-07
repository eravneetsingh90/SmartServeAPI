using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Brand : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual Tenant Tenant { get; set; } = null!;
}
