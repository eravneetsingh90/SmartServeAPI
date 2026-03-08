using SmartServe.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartServe.Domain.Entities;

public partial class Tenant : IEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Subdomain { get; set; }

    public string? Plan { get; set; }

    public string? Timezone { get; set; }

    public string? Currency { get; set; }

    public int? OrderCounter { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();

    public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
