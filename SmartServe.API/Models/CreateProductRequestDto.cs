namespace SmartServe.API.Models
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public string? FoodType { get; set; }   // VEG / NON_VEG

        public bool IsActive { get; set; } = true;

        public int DisplayOrder { get; set; } = 0;
    }
}