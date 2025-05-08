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
        public int KM { get; set; } = 0;

        [Required]
        public int Gap_KM { get; set; } = 0;

        [Required]
        public int Months { get; set; } = 0;

        [Required]
        public int Gap_Days { get; set; } = 0;

        [Required]
        public int TopServices { get; set; } = 0;

        [Required]
        public int? ExpirationMonths { get; set; } = 0;

        public int? BrandId { get; set; } = 0;

        public string? BrandName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

       
    }

}
