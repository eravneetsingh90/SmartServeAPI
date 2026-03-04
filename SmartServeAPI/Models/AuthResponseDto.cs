namespace SmartServe.API.Models
{
    public sealed class AuthResponseDto
    {
        public string AccessToken { get; init; } = default!;
        public int ExpiresInMinutes { get; init; }
    }
}
