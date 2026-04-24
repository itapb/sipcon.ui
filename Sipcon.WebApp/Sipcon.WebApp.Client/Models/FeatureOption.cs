using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class FeatureOption

    { 
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true; 
        public string Name { get; set; } = string.Empty;
        public int FeatureId { get; set; } = 0;
        public int OrderBy { get; set; } = 0;
    }
}
