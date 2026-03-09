using SmartServe.Domain.Entities;

namespace SmartServe.API.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
