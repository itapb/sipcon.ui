using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class CollectionMovementDetails : Record
    {


        [Required]
        [Range(0, int.MaxValue)]
        public int? MovementId { get; set; } = 0;

        [Required]
        [Range(0, int.MaxValue)]
        public int? PartId { get; set; } = 0;


        public int? PartialTypeId { get; set; }

    
        public string? PartInnerCode { get; set; } = string.Empty;

    
        public string? PartBarcode { get; set; } = string.Empty;

    

        public string? PartDescription { get; set; } = string.Empty;

    
        public string? PartSize { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int? LocationId { get; set; } = 0;


    
        public int? DestinationId { get; set; } = 0;


    
        public string DestinationName { get; set; } = string.Empty;


    
        [RegularExpression("^[RAD]$")]
        public string? LocationTypeId { get; set; } = string.Empty;

    
        public string LocationName { get; set; } = string.Empty;


    
        [RegularExpression("^[PE]$")]
        public string? TypeId { get; set; } = string.Empty;

    
        public string TypeName { get; set; } = string.Empty;


    
        public int? RequiredQty { get; set; } = 0;

        [Required]
        [Range(0, int.MaxValue)]
        public int? RealQty { get; set; } = 0;


        public string? SerialCode { get; set; } = string.Empty;

    
        public bool? Processed { get; set; } = false;


    
        public string UpdatedBy { get; set; } = string.Empty;

    
        public string UpdatedDate { get; set; } = string.Empty;


    
        [Range(0, int.MaxValue)]
        public int? UserId { get; set; } = 0;

    
        public string UserName { get; set; } = string.Empty;


    
        public int Mapping { get; set; } = 0;


    
        public decimal Cost { get; set; } = 0;

    
        public decimal SubTotal { get; set; } = 0;

    
        public int? Stock { get; set; } = 0;

    
        public bool? Serializable { get; set; } = false;


    
        public string? PartialTypeName { get; set; }

    
        public string? SaleOrderId { get; set; }

    
        public string? DealerName { get; set; }
    }
}
