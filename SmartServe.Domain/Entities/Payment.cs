using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Payment : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public int? OrderId { get; set; }

    public string? Mode { get; set; }

    public decimal? Amount { get; set; }

    public string? Status { get; set; }

    public string? TransactionRef { get; set; }

    public DateTime? PaidAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
