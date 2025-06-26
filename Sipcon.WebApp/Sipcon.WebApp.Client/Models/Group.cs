using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Group : Record
    {

        [Required]
        public string? Name { get; set; }

    }
}
