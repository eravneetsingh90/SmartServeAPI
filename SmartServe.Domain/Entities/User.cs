namespace SmartServe.Domain.Entities;

public partial class User : IEntity<int>
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

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
