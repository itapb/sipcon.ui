using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Zone : Record
    {

        [Required(ErrorMessage = "Zona es requerida.")]
        public string? Name { get; set; }

        [Required]
        public Int32? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }

        [Required]
        public string? Size { get; set; }
        public bool IsSelected { get; set; } = false;

    }
}
