using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Location : Record
    {

        [Required(ErrorMessage = "Campo requerido.")]
        public string? Name { get; set; }

        [Required]
        public Int32? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public string? WarehouseName { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Range(1, int.MaxValue, ErrorMessage ="Debe ser un valor mayor que cero")]
        public Int32? Mapping { get; set; }
        [Required]
        public string? TypeId { get; set; }
        public string? TypeName { get; set; }

    }
}
