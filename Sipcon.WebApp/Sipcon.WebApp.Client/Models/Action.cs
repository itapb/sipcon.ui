using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Action
    {

        [Required]
        public int? UserId { get; set; }

        [Required]
        public int? RecordId { get; set; }

        [Required]
        public int? ModuleId { get; set; }

        [Required]
        public int? ActionId { get; set; }

        public string? ActionComment { get; set; }

        public int RelatedId { get; set; }

    }
}
