using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Fase  
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int? OrderBy { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int? AreaId { get; set; }

        [Required]
        public int? SupplierId { get; set; }

        public int? DealerId { get; set; }

        [Required]
        public bool? IsActive { get; set; }

        public string? AreaName { get; set; } 
         
        public string? SupplierName { get; set; } 
         
        public string? DealerName { get; set; }
         
        public DateTime? Updated { get; set; }
         
        public string? UpdatedBy { get; set; }
    }
}
