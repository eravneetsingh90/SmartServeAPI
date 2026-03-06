using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class RoleEntity : IEntity<int>
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

    public virtual ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();

    public virtual ICollection<UserEntity> UsersNavigation { get; set; } = new List<UserEntity>();
}
