using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class SaleOrder : Record
    {
        [Required]
        public int? DealerId { get; set; }     
        public string? DealerName { get; set; }
        [Required]
        public int? SupplierId { get; set; }       
        public string? SupplierName { get; set; }      
        public int? StatusId { get; set; }       
        public string? StatusName { get; set; }
        [Required]
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public string? Reference { get; set; }
        public string? Comment { get; set; }
        public string Created { get; set; } = "";        
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsClaim { get; set; } = false;
        public bool? Paralyzed { get; set; } = false;
        public int? VehicleId { get; set; } = 0;               
        public string? VehicleVin { get; set; }        
        public string? VehicleCustomer { get; set; }
        public int? CustomerId { get; set; }
        public string? Customer { get; set; }
        public string? CustomerVat { get; set; }
        public int? GroupId { get; set; }


    }
}
