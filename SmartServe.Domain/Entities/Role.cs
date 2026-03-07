using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Role : IEntity<int>
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<User> UsersNavigation { get; set; } = new List<User>();
}
