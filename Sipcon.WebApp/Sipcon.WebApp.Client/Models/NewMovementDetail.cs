using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class NewMovementDetail
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int? Id { get; set; } = 0;

        [Required]
        [Range(1, int.MaxValue)]
        public int? MovementId { get; set; } = 0;

        [Required]
        [Range(1, int.MaxValue)]
        public int? PartId { get; set; } = 0;

        [Required]
        [Range(0, int.MaxValue)]
        public int? LocationId { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int? DestinationId { get; set; } = 0;

        [Required( ErrorMessage ="Campo requerido")]
        [Range(1, int.MaxValue , ErrorMessage ="Debe ser mayor que creo")]
        public int? RequiredQty { get; set; }
    }
}
