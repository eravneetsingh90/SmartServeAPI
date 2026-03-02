using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace SmartServe.API.Models
{
    public class LoginRequestDto
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("pin")]
        public string? Pin { get; set; }
    }
}
