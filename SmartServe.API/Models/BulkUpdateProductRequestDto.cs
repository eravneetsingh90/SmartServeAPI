namespace SmartServe.API.Models
{
    public class BulkUpdateProductRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public string? FoodType { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}