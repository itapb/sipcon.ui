using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class City : Record
    {
        [Required]
        public string? State { get; set; }

        [Required]
        public string? Name { get; set; }
    }

}
