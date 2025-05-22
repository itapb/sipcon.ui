using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PolicyType
    {


        [Required]
        public int Id { get; set; } = 0;
         
        [Required]
        public string Description { get; set; } = string.Empty;
         
        [Required]
        public int? KM { get; set; } = null;

        [Required]
        public int? GapKM { get; set; } = null;

        [Required]
        public int? Months { get; set; } = null;

        [Required]
        public int? GapMonths { get; set; } = null;

        [Required]
        public int? TopKM { get; set; } = null;

        [Required]
        public int? TopMonths { get; set; } = null;

        [Required]
        public int? BrandId { get; set; } = null;

        public string BrandName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

       
    }

}
