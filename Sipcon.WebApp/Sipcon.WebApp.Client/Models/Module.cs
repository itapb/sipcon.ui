using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Module
    {

        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ActionName { get; set; } = string.Empty;

        [Required]
        public string ActionDisplay { get; set; } = string.Empty;

    }

}
