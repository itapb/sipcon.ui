using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Invoicecontrol : Record
    {

        
        public int? InvoiceId { get; set; }

        
        public int? ControlId { get; set; }

        
        public int? Invoiced { get; set; }

        
        public int? Dispatched { get; set; }

        [Required]
        public bool? Mark { get; set; }

        
        public int? UserSinc { get; set; }

        
        public DateTime? ControlDate { get; set; }


        
        public DateTime? SincDate { get; set; }

        
        public decimal? Price { get; set; }

        //CUSTOMER
        
        public string? CustomerId { get; set; }
        
        public string? Vat { get; set; }
        
        public string? FiscalName { get; set; }

        //SUPPLIER  
        
        public string? SupplierName { get; set; }

        //PART
        
        public string? PartInnerCode { get; set; }
        
        public string? PartName { get; set; }

        //SALE ORDER
        
        public int? SaleOrderNumber { get; set; }

        //MOVEMENTDETAILS
        
        public string? LocationName { get; set; }

        //PACKAGELIST
        
        public int? Required { get; set; }

        
        public int? BackOrderId { get; set; }

        
        public int? MovementDetailId { get; set; }

        
        public int? PartId { get; set; }

        
        public int? SupplierId { get; set; }

        
        public int? Pending { get; set; }

        public string? StatusName { get; set; }

        public string? SaleOrderType { get; set; }

        public int? CustomerInvoiceId { get; set; }

        public string? CustomerInvoice { get; set; }
        public string? CustomerVat { get; set; }
        //Tipo A-B  

        public string? Type { get; set; }


    }
}
