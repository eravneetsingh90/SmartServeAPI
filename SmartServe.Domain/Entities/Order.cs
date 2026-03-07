using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Order : IEntity<int>
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public string? OrderType { get; set; }

    public string? OrderSource { get; set; }

    public int? TableId { get; set; }

    public int? StatusId { get; set; }

    public int? CreatedBy { get; set; }

    public decimal? OriginalAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public string? DiscountReason { get; set; }

    public string? PaymentStatus { get; set; }

    public bool? IsTracked { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual TableStatus? Status { get; set; }

    public virtual RestaurantTable? Table { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
