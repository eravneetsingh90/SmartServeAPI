namespace SmartServe.Application.Models
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = default!;

        public DateTime ExpiresAt { get; set; }

        public string Username { get; set; } = default!;

        public string Role { get; set; } = default!;
    }
}
