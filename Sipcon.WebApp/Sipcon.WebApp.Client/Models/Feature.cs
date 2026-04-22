using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Feature
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public bool? DefaultValue { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int? FeatureTypeId { get; set; } 

        [Required(ErrorMessage = "Campo requerido.")]
        public int? ModelId { get; set; }

        [Required]
        public int? SupplierId { get; set;} 

        public int? DealerId { get; set; }

        [Required]
        public bool? IsActive { get; set; }
        public string? FeatureTypeName { get; set; }
         
        public string? ModelName { get; set; }
         
        public int? FaseId { get; set; }
         
        public string? FaseName { get; set; }
         
        public int? AreaId { get; set; }
         
        public string? AreaName { get; set; } 
         
        public string? SupplierName { get; set; } 
         
        public string? DealerName { get; set; }
         
        public DateTime? Updated { get; set; }
         
        public string? UpdatedBy { get; set; }
    }
}
