using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Family: Record
    {
        [Required]
        public String? Name { get; set; }

        [Required]
        public Int32? PartTypeId { get; set; }

        [Required]
        public String? PartTypeName { get; set; }
    }
}
