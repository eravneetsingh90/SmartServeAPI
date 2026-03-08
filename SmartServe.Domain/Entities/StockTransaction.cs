using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class StockTransaction : IEntity<int>, ITenantEntity
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public int StockId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string Reason { get; set; } = null!;

    public string? ReferenceType { get; set; }

    public int? ReferenceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Stock Stock { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
