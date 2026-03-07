using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class UserEntity : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public string? Username { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string? PinHash { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    public virtual RoleEntity? Role { get; set; }

    public virtual TenantEntity Tenant { get; set; } = null!;

    public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
}
