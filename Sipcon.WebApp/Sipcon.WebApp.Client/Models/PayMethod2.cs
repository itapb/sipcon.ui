using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PayMethod2 : Record
    {

        [Required]
        public string? Name { get; set; }

    }
}
