using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class RestaurantTable : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string DisplayName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Tenant Tenant { get; set; } = null!;
}
