using System.ComponentModel.DataAnnotations;

namespace SmartServe.API.Models
{
    public class CreateCategoryRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; } = 0;
    }
}
