using System.Text.Json.Serialization;

namespace SmartServe.API.Models
{
    public class MetaDataDto
    {
        [JsonPropertyName("resultCode")]
        public string ResultCode { get; set; }
        [JsonPropertyName("resultMessage")]
        public string ResultMessage { get; set; }
    }
}
