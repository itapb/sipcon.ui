using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{

    public class Module
    {
       
        public int Total { get; set; } = 0;
        
       
        public List<TModule> Modules { get; set; } = [];

    }


    public class TModule
    {

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ActionName { get; set; } = string.Empty;

        [Required]
        public string actionDisplay { get; set; } = string.Empty;

    }

}
