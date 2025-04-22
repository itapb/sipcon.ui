using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Brand : Record

    {
        [Required]
        public string? Name { get; set; }
    }
}
