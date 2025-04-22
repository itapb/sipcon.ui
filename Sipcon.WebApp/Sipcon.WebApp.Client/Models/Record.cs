using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Record
    {
        [Required]
        public int? Id { get; set; }
       
        public int Total { get; set; }

        [Required]
        public bool? IsActive { get; set; }
       
        public string? Created { get; set; }
        
        public string? Updated { get; set; }
      
        public string? UpdatedBy { get; set; }


    }
}
