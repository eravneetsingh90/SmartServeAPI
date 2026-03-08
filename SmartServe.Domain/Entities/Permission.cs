using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Permission : IEntity<int>
{
    public int Id { get; set; }

    public string PermissionCode { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
