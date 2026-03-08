using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Category : IEntity<int>, ITenantEntity
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Tenant Tenant { get; set; } = null!;
}
