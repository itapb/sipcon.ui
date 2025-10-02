namespace Sipcon.WebApp.Client.Pages.Mobile.Models
{
    public class PackageList
    {
       
        public Int32? Id { get; set; }
       
        public string? Code { get; set; }
       
        public Int32? SupplierId { get; set; }
       
        public Int32? CustomerId { get; set; }
       
        public string? SupplierName { get; set; }
       
        public string? CustomerName { get; set; }
      
        public string? PartInnerCode { get; set; }
       
        public string? PartName { get; set; }
       
        public Int32? Quantity { get; set; }
    }
}
