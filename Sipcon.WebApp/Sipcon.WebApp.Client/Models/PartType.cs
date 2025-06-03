using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PartType : Record
    {
        [Required]
        public String? Name { get; set; }
    }
}
