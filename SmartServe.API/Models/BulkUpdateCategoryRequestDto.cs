using System.ComponentModel.DataAnnotations;

namespace SmartServe.API.Models
{
    public class BulkUpdateCategoryRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
