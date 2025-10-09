using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PartExternal
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public int ModelId { get; set; }
        public bool IsActive { get; set; } = true;


    }

    public class PartExternalUp 
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public bool IsActive { get; set; } = true;


    }

}
