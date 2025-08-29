namespace Sipcon.WebApp.Client.Models
{
    public class GuideDetails
    {
        public int? Id { get; set; }
        public int? GuideId { get; set; }
        public   int?  PartId  { get; set; }
        public string?  PartInnercode  { get; set; }
        public string?  PartDescription { get; set; }
        public int? Quantity { get; set; }
        public string? PackageId { get; set; }
        public int?  PackageNumber { get; set; }
        public string? PackageCode { get; set; }
        public int? Received { get; set; }
        public string? Observation  { get; set; }
        public int? SaleOrderId { get; set; }
        public bool? Confirmed { get; set; }

    }
}