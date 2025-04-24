using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{

    public class Vehicle
    {
        [Required]
        public int Total { get; set; } = 0;

        public List<TVehicle> Vehicless { get; set; } = [];

    }



    public class TVehicle
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Vin { get; set; } = string.Empty;

        [Required]
        public string EngineSerial { get; set; } = string.Empty;

        [Required]
        public string BodySerial { get; set; } = string.Empty;

        [Required]
        public string Plate { get; set; } = string.Empty;

        [Required]
        public int? ColorId { get; set; } 

       
        public string ColorName { get; set; } = string.Empty;

        [Required]
        public int? ModelId { get; set; }

  
        public string ModelName { get; set; } = string.Empty;

        [Required]
        public int? BrandId { get; set; }

      
        public string BrandName { get; set; } = string.Empty;

        [Required]
        public int? Year { get; set; }

        [Required]
        public int? SupplierId { get; set; }

       
        public string SupplierName { get; set; } = string.Empty;

        [Required]
        public int? DealerID { get; set; }

       
        public string DealerName { get; set; } = string.Empty;

        [Required]
        public int? CustomerId { get; set; }

       
        public string CustomerName { get; set; } = string.Empty;
                
        [Required]
        public int? IsActive { get; set; }


    }

}
