using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{

    public class Model
    {
        [Required]
        public int Total { get; set; } = 0;
        
        [Required]
        public List<TModel> Models { get; set; } = [];

    }


    public class TModel
    {

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int? BrandId { get; set; }


        [Required]
        public int? PolicyTypeId { get; set; }

        public string PolicyTypeName { get; set; } = string.Empty;

        [Required]
        public bool? IsActive { get; set; } = true;


    }

}
