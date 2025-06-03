using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PayMethod
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;  
    }
}
