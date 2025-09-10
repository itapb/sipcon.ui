using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Zone : Record
    {

        [Required(ErrorMessage = "Campo requerido.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La longitud debe ser entre 5 y 20 caracteres.")]
        public string? Name { get; set; }

        [Required]
        public Int32? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }

        [Required]
        public string? Size { get; set; }
       

    }
}
