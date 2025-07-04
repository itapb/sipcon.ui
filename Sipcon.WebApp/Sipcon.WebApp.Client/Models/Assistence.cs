using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Assistence
    {
      
    
        /// <summary>
        /// Service information
        /// </summary>
        [Required]
        public int Id { get; set; } = 0;
        [Required]
        public int? ServiceTypeId { get; set; } = null;
        public string ServiceTypeName { get; set; } = string.Empty;
        [Required]
        public int? ReportTypeId { get; set; } = null;
        //public string ReportTypeName { get; set; } = string.Empty;
        public DateTime? ServiceDate { get; set; } = null;
        public string CustomerReport { get; set; } = string.Empty;
        public string DealerReport { get; set; } = string.Empty;
        public string TechnicalSolution { get; set; } = string.Empty;
        public string SupplierReport { get; set; } = string.Empty;
        [Required]
        public int? OrderNumber { get; set; } = null;
        [Required]
        public int? Km { get; set; } = null;
        public int? EstatusId { get; set; } = null;
        public string EstatusName { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } = true;


        /// <summary>
        /// Policy information
        /// </summary>
        public string? NumberPolicy { get; set; } = null;

        /// <summary>
        /// Dealer information
        /// </summary>
        [Required]            
        public int? DealerId { get; set; } = null;
        public string DealerServiceName { get; set; } = string.Empty; 
        public string DealerServiceCod { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle information
        /// </summary>
        [Required]            
        public int? VehicleId { get; set; } = null;  
        public string Plate { get; set; } = string.Empty;
        public string Vin { get; set; } = string.Empty; 
        public int? ModelId { get; set; } = null;  
        public string ModelName { get; set; } = string.Empty;  
        public string? Year { get; set; } = null;

        /// <summary>
        /// Customer information
        /// </summary>
        [Required]
        public int? CustomerId { get; set; } = null;  
        

    }

    public class AssistenceUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int OrderNumber { get; set; } = 0;
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        public string CustomerReport { get; set; } = string.Empty;
        public string DealerReport { get; set; } = string.Empty;
        public string TechnicalSolution { get; set; } = string.Empty;
        public int Km { get; set; } = 0; 
        public int DealerId { get; set; } = 0;
        public int VehicleId { get; set; } = 0;
        public int CustomerId { get; set; } = 0;

    }

}
