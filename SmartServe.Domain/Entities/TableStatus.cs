using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class TableStatus : IEntity<int>
{
    public int Id { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? StatusName { get; set; }

    public string? ColorHex { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
