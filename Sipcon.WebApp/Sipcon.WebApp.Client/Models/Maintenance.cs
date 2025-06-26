using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Maintenance
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
        public string ReportTypeName { get; set; } = string.Empty;
        [Required]
        public DateTime? ServiceDate { get; set; } = null;
        [Required]
        public string DealerReport { get; set; } = string.Empty;
        [Required]
        public string SupplierReport { get; set; } = string.Empty;
        [Required]
        public int? OrderNumber { get; set; } = null;
        [Required]
        public string SrgNumber { get; set; } = string.Empty;
        [Required]
        public int? Km { get; set; } = null;
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public int? EstatusId { get; set; } = null;
        public string EstatusName { get; set; } = string.Empty;
        public string AuthorizedUserName { get; set; } = string.Empty;
        public string AuthorizedUserLastName { get; set; } = string.Empty;


        /// <summary>
        /// Policy information
        /// </summary>
        public int? PolicyDetailId { get; set; } = null;
        public string? NumberPolicy { get; set; } = null;


        /// <summary>
        /// Dealer information
        /// </summary>
        [Required]            
        public int? DealerId { get; set; } = null;
        public string DealerServiceName { get; set; } = string.Empty; 
        public string DealerServiceCod { get; set; } = string.Empty;
        public string DealerAddress { get; set; } = string.Empty;
        public string DealerServiceCity { get; set; } = string.Empty;
        public string DealerServiceState { get; set; } = string.Empty;

        /// <summary>
        /// Dealer Sale information
        /// </summary>
        [Required]            
        public int? DealerSaleId { get; set; } = null;
        public string DealerSaleName { get; set; } = string.Empty;
        public string DealerSaleCod { get; set; } = string.Empty;
        
        /// <summary>
        /// Vehicle information
        /// </summary>
        [Required]            
        public int? VehicleId { get; set; } = null;  
        public string Plate { get; set; } = string.Empty;
        public string Vin { get; set; } = string.Empty; 
        [Required]            
        public int? ModelId { get; set; } = null;  
        public string ModelName { get; set; } = string.Empty;  
        public string? Year { get; set; } = null;


        /// <summary>
        /// Customer information
        /// </summary>
        [Required]            
        public int? CustomerId { get; set; } = null; 
        public string Vat { get; set; } = string.Empty; 
        public string CustomerName { get; set; } = string.Empty; 
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;


        /// <summary>
        /// Invoice information
        /// </summary>
        [Required]            
        public string InvoiceNumber { get; set; } = string.Empty;
        [Required]            
        public double? InvoiceAmount { get; set; } = null;
        [Required]            
        public DateTime? InvoiceDate { get; set; } = null;

    }

    public class MaintenanceUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int OrderNumber { get; set; } = 0;
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        public string DealerReport { get; set; } = string.Empty;
        public int PolicyDetailId { get; set; } = 0;
        public int Km { get; set; } = 0; 
        public int DealerId { get; set; } = 0;
        public int VehicleId { get; set; } = 0;
        public int CustomerId { get; set; } = 0;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
    }

   

}
