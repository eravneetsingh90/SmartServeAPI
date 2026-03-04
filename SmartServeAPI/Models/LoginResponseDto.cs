using SmartServe.EFCore.Models;

namespace SmartServe.API.Models
{
    public class LoginResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? RoleId { get; set; }

        public string? PinHash { get; set; }

        public bool? IsActive { get; set; }

        
    }
}
