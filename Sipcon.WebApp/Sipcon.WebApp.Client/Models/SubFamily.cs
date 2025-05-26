using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class SubFamily: Record
    {
        [Required]
        public String? Name { get; set; }

        [Required]
        public Int32? FamilyId { get; set; }

        [Required]
        public String? FamilyName { get; set; }
    }
}
