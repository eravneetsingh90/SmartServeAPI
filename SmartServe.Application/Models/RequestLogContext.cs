namespace SmartServe.Application.Models
{
    public class RequestLogContext
    {
        public string Action { get; set; }
        public string? TenantCode { get; set; }

        public int? UserId { get; set; }

        public int StatusCode { get; set; }

        public string ResultCode { get; set; }

        public string ResultMessage { get; set; }

        public List<string> Errors { get; set; } = new();
    }
}
