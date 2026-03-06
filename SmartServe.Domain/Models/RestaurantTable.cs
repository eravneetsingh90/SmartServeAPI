using SmartServe.EFCore.Entities;

namespace SmartServe.Domain.Models
{
	public class RestaurantTable
	{
		public int Id { get; set; }

		public string DisplayName { get; set; } = null!;

		public bool? IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }

		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}
