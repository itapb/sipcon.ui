namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class Guide
    {
        public int?  Id { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName  { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName  { get; set; }
        public int? ProviderId { get; set; }
        public string?  ProviderName { get; set; }
        public string? Number { get; set; }
        public DateTime?  CreatedDate  { get; set; }
        public DateTime? DeliveredDate  { get; set; }
        public string? StatusName  { get; set; }
        public int? UserId  { get; set; }
        public bool? Delivered { get; set; }
        public bool? Closed { get; set; }
        public decimal? Weith { get; set; } = 0;
        public bool IsSelected { get; set; } = false;
    }
}
