
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class PowerBI_Reports : Record
    {
        public string? Report { get; set; }
        public string? ReportId { get; set; }
        public string? WorkSpace { get; set; }
        public string? WorkSpaceId { get; set; }
    }

    public class PowerBI_ReportPortal
    {
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public string? ReportId { get; set; }
        public string? embedUrl { get; set; }
    }

    public class PowerBI_Token
    {
        public string? Token { get; set; }
    }
}
