namespace SmartServe.API.Helper
{
    public class AppSettings
    {
        
    }
    
    public sealed class JwtSettings
    {
        public const string SectionName = "Jwt";

        public string Key { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int DurationInMinutes { get; init; }
    }
}
