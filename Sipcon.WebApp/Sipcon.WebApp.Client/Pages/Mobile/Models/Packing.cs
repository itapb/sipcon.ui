namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class Packing
    {
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int? PackageId { get; set; }
        public int? PartId { get; set; }
        public String? CustomerName { get; set; } = string.Empty;
        public int? Pending { get; set; }
        public int? Quantity { get; set; }
        public String? PartName { get; set; }
        public String? Code { get; set; }
        public bool? PackageClosed { get; set; }
        public int? Number { get; set; }
    }

    public enum PackingStep
    {
        Customer = 0,
        PackingDetails = 1,
        Package = 2,
        Pending = 3,
        SetPackage = 4,
        DispatchGuide = 5,
    }
}
