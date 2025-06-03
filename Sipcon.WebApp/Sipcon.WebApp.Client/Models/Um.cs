using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Um:Record
    {

        [Required]
        public string? Name { get; set; }

    }

}
