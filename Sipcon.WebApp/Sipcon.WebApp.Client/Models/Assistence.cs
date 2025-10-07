using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Assistence
    {
      
    
        /// <summary>
        /// Service information
        /// </summary>
        public int Id { get; set; } = 0;
        public int? ServiceTypeId { get; set; } = null;
        public string ServiceTypeName { get; set; } = string.Empty;
        public int? ReportTypeId { get; set; } = null;
        //public string ReportTypeName { get; set; } = string.Empty;
        public DateTime? ServiceDate { get; set; } = null;
        public string CustomerReport { get; set; } = string.Empty;
        public string DealerReport { get; set; } = string.Empty;
        public string TechnicalSolution { get; set; } = string.Empty;
        public string SupplierReport { get; set; } = string.Empty;
        public string? OrderNumber { get; set; } = string.Empty;
        public int? Km { get; set; } = null;
        public int? EstatusId { get; set; } = null;
        public string EstatusName { get; set; } = string.Empty;
        public bool? Paralyzed { get; set; } = false;
        public int? AssistanceTypeId { get; set; } = null;
        public string? AssistanceType { get; set; } = string.Empty;
        public int? PossibleFaultId { get; set; } = null;
        public string PossibleFault { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public int? Assesment { get; set; } = null;
        public string? AuthorizedUserName { get; set; } = string.Empty; 
        public bool IsActive { get; set; } = true;


        /// <summary>
        /// Policy information
        /// </summary>
        public string? NumberPolicy { get; set; } = null;

        /// <summary>
        /// Dealer information
        /// </summary>
        public int? DealerId { get; set; } = null;
        public string DealerServiceName { get; set; } = string.Empty; 
        public string DealerServiceCod { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle information
        /// </summary>
        public int? VehicleId { get; set; } = null;  
        public string Plate { get; set; } = string.Empty;
        public string Vin { get; set; } = string.Empty; 
        public int? ModelId { get; set; } = null;  
        public string ModelName { get; set; } = string.Empty;  
        public string? Year { get; set; } = null;

        /// <summary>
        /// Customer information
        /// </summary>
        public int? CustomerId { get; set; } = null;  
        

    }

    public class AssistenceUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        public string CustomerReport { get; set; } = string.Empty;
        public string DealerReport { get; set; } = string.Empty;
        public int Km { get; set; } = 0;
        public bool Paralyzed { get; set; } = false;
        public int DealerId { get; set; } = 0;
        public int VehicleId { get; set; } = 0;
        public int CustomerId { get; set; } = 0;
        public int PossibleFaultId { get; set; } = 0;

    }

}
