using System.ComponentModel.DataAnnotations;

namespace SmartServe.API.Models
{
    public class CategoryUpdateRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
