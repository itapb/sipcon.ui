namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class Dispatch
    {
    
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int? GuideId { get; set; }
        public int? PackageId { get; set; }
        public int? PartId { get; set; }
        public String? CustomerName { get; set; } = string.Empty;

    }
    public enum DispatchStep
    {  
        Customer = 0,
        Guides = 1,
        GuideDetails = 2,
        Package = 3,
        Pending = 4,
        SetPackage = 5,
    }
}