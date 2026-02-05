using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ClaimPart: Record
    {

        [Required]
        public int? SupplierId { get; set; }
        [Required]
        public int? DealerId { get; set; }
        [Required]
        public int? UserId { get; set; }

        public string? Reference { get; set; }
        public string? Note { get; set; }
        public string? Comment { get; set; }
        public string? Invoice { get; set; }
        public string? Guide { get; set; }

      
        public string? DealerName { get; set; }
      
        public string? SupplierName { get; set; }
     
        public string? StatusName { get; set; }
       
        public string? Login { get; set; }
      
        public string? FiscalName { get; set; }
  
        public DateTime? DCreated { get; set; }
       
        public DateTime? DUpdated { get; set; }
                
        public string? PartName { get; set; }
        public string? ReasonDescription { get; set; }
        public string? PartInnerCode { get; set; }
    }
}
