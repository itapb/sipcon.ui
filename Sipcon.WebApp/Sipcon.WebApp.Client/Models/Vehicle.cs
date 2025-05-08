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
        public int ColorId { get; set; } = 0;

        public string ColorName { get;  set; } = string.Empty;

        [Required]
        public int ModelId { get; set; } = 0;

        public string ModelName { get;  set; } = string.Empty;

        
        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int BrandId { get; set; } = 0;
      
        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string BrandName { get;  set; } = string.Empty;

        [Required]
        public int Year { get; set; } = 0;

        [Required]
        public int SupplierId { get; set; } = 0;

        public string SupplierName { get;  set; } = string.Empty;

        [Required]
        //[JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int DealerId { get; set; } = 0;

        public string DealerName { get;  set; } = string.Empty;

        [Required]
        //[JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int CustomerId { get; set; } = 0;

        public string CustomerName { get;  set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;


    }

}
