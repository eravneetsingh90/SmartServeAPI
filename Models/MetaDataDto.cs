using System.Text.Json.Serialization;

namespace SmartServe.API.Models
{
    public class MetaDataDto
    {
        [JsonPropertyName("resultCode")]
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
