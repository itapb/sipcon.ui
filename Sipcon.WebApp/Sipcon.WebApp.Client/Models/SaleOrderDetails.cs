using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class SaleOrderDetails : Record
    {

        [Required]
        public int? SaleOrderId { get; set; }

        [Required]
        public int? PartId { get; set; }
     
        public string? PartInnerCode { get; set; }
     
        public string? PartName { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public int? Invoiced { get; set; }

        public int? ReasonId { get; set; }

        public decimal? Cost { get; set; }

        public decimal? Price { get; set; }

        public int Claim { get; set; }

        public decimal? TaxAmount { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
