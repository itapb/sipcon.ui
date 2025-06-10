using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Movement: Record
    {
        [Required]
        [Range(1, int.MaxValue)]
        public Int32? SupplierId { get; set; }

        [Required]
        public string? TypeId { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
       
        public DateTime Created { get; set; } = DateTime.Now;
       
        public string TypeName { get; set; } = string.Empty;
      
        public string StatusName { get; set; } = string.Empty;
       
        public string SupplierReference { get; set; } = string.Empty;

        public string Reference { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public string AssignTo { get; set; } = string.Empty;
    }
}
