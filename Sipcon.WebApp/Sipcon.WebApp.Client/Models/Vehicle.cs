using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public string Vin { get; set; } = string.Empty;

        [Required]
        public string EngineSerial { get; set; } = string.Empty;

        [Required]
        public string Plate { get; set; } = string.Empty;

        [Required]
        public int? ColorId { get; set; } = null;

        public string ColorName { get;  set; } = string.Empty;

        [Required]
        public int? ModelId { get; set; } = null;

        public string ModelName { get;  set; } = string.Empty;

        
        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? BrandId { get; set; } = null;

        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string BrandName { get;  set; } = string.Empty;

        [Required]
        public int? Year { get; set; } = null;

        [Required]
        public int? SupplierId { get; set; } = null;

        public string SupplierName { get;  set; } = string.Empty;

        public string SupplierReference { get; set; } = string.Empty;

        [Required]
        //[JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int? DealerId { get; set; } = null;

        public string DealerName { get;  set; } = string.Empty;

        public string DealerReference { get; set; } = string.Empty;

        [Required]
        //[JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int? CustomerId { get; set; } = null;    

        public string CustomerName { get;  set; } = string.Empty;

        public string EstatusName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;


    }

}
