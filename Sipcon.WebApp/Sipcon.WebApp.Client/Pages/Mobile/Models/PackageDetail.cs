namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class PackageDetail
    {
        public int?  Id { get; set; }
        public int? PackageId { get; set; }
        public string? packageCode { get; set; }
        public int?  PartId { get; set; }

        public string? PartName { get; set; }
        public string?  PartInnerCode { get; set; }
        public string?  PartBarCode { get; set; }
        public int? Quantity { get; set; }
    }
}
