namespace Sipcon.WebApp.Client.Models
{
    public class BackOrder : Record
    {
        public string? PartDescription { get; set; }
        public string? PartInnerCode { get; set; }
        public string? SupplierId { get; set; }
        public int? Quantity { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DealerId { get; set; }
        public string? DealerName { get; set; }
        public int? SaleOrderNumber { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }

    }
}
