using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class InventoryCount : Record
    {

        [Required]
        public String? Name { get; set; }

        [Required]
        public decimal? Amount { get; set; }

    }
}
