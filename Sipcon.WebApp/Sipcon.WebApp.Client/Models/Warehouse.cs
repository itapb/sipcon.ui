using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Warehouse : Record
    {
        [Required(ErrorMessage = "Campo requerido.")]
        public string? Name { get; set; }
        [Required]
        public Int32? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? BrandName { get; set; }
        public bool? Sell { get; set; } = true;
       
    }

}
