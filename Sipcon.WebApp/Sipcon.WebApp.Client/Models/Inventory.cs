using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Inventory:Record
    {
        [Required]
        [Range(1, int.MaxValue)]
        public Int32? LocationId { get; set; }
        public string? LocationName { get; set; }
        public Int32? ZoneId { get; set; }       
        public string? ZoneName { get; set; }
        public Int32? WarehouseId { get; set; }    
        public string? WarehouseName { get; set; }       
        public Int32? SupplierId { get; set; }
        public string? SupplierName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? PartId { get; set; }    
        public string? PartInnerCode { get; set; }       
        public string? PartName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public Int32? Stock { get; set; }
        public decimal? Price { get; set; } = decimal.Zero;
    }
}
