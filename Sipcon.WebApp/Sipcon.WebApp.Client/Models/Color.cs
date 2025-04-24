using System.ComponentModel.DataAnnotations;


namespace Sipcon.WebApp.Client.Models
{
    public class Color
    {
       
        public int Total { get; set; } = 0;
        
        public List<TColor> Colors { get; set; } = [];
               
    }
    
    
    public class TColor
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

    }
}
