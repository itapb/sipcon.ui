using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sipcon.WebApp.Client.Models
{
    public class RelatedModel
    {
        [Required]
        public int? ModelId { get; set; }      
        public string? ModelName { get; set; }
        [Required]
        public bool IsRelated { get; set; }
        [Required]
        public int PartId { get; set; }       
        public string? PartName { get; set; }      
        public int SupplierId { get; set;}
        public override string ToString() => ModelName!;
    }
}
