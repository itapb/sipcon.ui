using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class AdjustmentDetails : Record
    {
        [Required]
        public int? AdjustmentId { get; set; }

        [Required]
        public int? LocationId { get; set; }

        [Required]
        public int? PartId { get; set; }

        [Required]
        public int? Stock { get; set; }

        [Required]
        public int? ReasonId { get; set; }

        [Required]
        public string? AdjustmentType { get; set; }

       
        public string? Zone { get; set; }

        
        public string? Warehouse { get; set; }

        
        public string? Location { get; set; }

        
        public string? Inncercode { get; set; }

       
        public string? PartDescription { get; set; }

       
        public decimal? PartPrice { get; set; }

        
        public string? PartSize { get; set; }

       
        public string? ReasonDescription { get; set; }
        public decimal? Cost { get; set; }
    }
}
