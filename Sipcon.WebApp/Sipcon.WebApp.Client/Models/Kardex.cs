using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Kardex: Record
    {
        [Required]
        [Range(1, int.MaxValue)]
        public Int32? SupplierId { get; set; }
        public Int32? PartId { get; set; } =0;
        public string? PartCode { get; set; } = string.Empty;
        public string? PartName { get; set; } = string.Empty;
        public Int32? ReferenceId { get; set; }=0;
        public string? Type { get; set; } = string.Empty;
        public Int32? Quantity { get; set; } = 0;
        public Int32? QuantityOld { get; set; } = 0;
        public Int32? QuantityNew { get; set; } = 0;
        public decimal? Cost { get; set; } = 0;
        public String? Created { get; set; } = String.Empty;
        public string? UserName { get; set; } = string.Empty;
    }
}
