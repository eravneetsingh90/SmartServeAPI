using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class TableStatusEntity : IEntity<int>
{
    public int Id { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? StatusName { get; set; }

    public string? ColorHex { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
