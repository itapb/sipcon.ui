namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class Guide
    {
        public int?  Id { get; set; }
        public int? SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProviderId { get; set; }
        public String? Number { get; set; }
        public bool? Delivered { get; set; }
    }
}
