using System;
using System.Collections.Generic;

namespace SmartServe.EFCore.Entities;

public partial class PaymentEntity : IEntity<int>
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

    public virtual OrderEntity? Order { get; set; }

    public virtual TenantEntity Tenant { get; set; } = null!;
}
