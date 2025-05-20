using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Model
    {
        [Required]
        public int? BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? PolicyTypeId { get; set; } 

        public string PolicyTypeName { get; set; } = string.Empty;
        
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;


    }

}
