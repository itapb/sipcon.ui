using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Adjustment : Record
    {

        [Required]
        public int? SupplierId { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        public int? StatusId { get; set; }

        public string? Comment { get; set; }

     
        public string? StatusName { get; set; }

     
        public DateTime? DCreated { get; set; }

     
        public string? UserLogin { get; set; }

     
        public string? SupplierName { get; set; }
     
        public DateTime? DUpdated { get; set; }
    }
}
