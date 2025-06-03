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
       

    }
}
