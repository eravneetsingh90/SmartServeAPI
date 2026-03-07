using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class PermissionEntity : IEntity<int>
{
    public int Id { get; set; }

    public string PermissionCode { get; set; } = null!;

    public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
}
