using System.ComponentModel.DataAnnotations;


namespace Sipcon.WebApp.Client.Models
{
    public class VehicleColor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
