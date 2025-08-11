using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class FailReport
    {
      
        public int Id { get; set; } = 0;
        public int? ServiceTypeId { get; set; } = null;
        public string ServiceTypeName { get; set; } = string.Empty;
        public int? ReportTypeId { get; set; } = null;
        public string ReportTypeName { get; set; } = string.Empty;
        public int? EstatusId { get; set; } = null;
        public string EstatusName { get; set; } = string.Empty;
        public DateTime? ServiceDate { get; set; } = null;
        public string CustomerReport { get; set; } = string.Empty;
        public string DealerReport { get; set; } = string.Empty;
        public string TechnicalSolution { get; set; } = string.Empty;
        public string SupplierReport { get; set; } = string.Empty;
        public int? OrderNumber { get; set; } = null;
        public int? KM { get; set; } = null;

        public int? SupplierId { get; set; } = null;
        public int? BrandId { get; set; } = null;
        public string SrgNumber { get; set; } = string.Empty;
        public bool Paralyzed { get; set; } = false;
        public bool IsActive { get; set; } = true;


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
        public string DealerSaleId { get; set; } = string.Empty; 
        public string DealerSaleName { get; set; } = string.Empty; 
        public string DealerSaleCod { get; set; } = string.Empty; 

        /// <summary>
        /// Vehicle information
        /// </summary>
        [Required]            
        public int? VehicleId { get; set; } = null;  
        public string Plate { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty; 
        public int? ModelId { get; set; } = null;  
        public string ModelName { get; set; } = string.Empty;  
        public string? Year { get; set; } = null;
        


        /// <summary>
        /// Customer information
        /// </summary>
        public int? CustomerId { get; set; } = null;
        public string VAT { get; set; } = string.Empty; 
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty; 
        public string CustomerPhone { get; set; } = string.Empty;


        /// <summary>
        /// Invoice information
        /// </summary>
        public string InvoiceNumber { get; set; } = string.Empty;
        public double? InvoiceAmount { get; set; } = null;
        public DateTime? InvoiceDate { get; set; } = null;
        public double? Tax { get; set; } = null;
        public double? TaxBase { get; set; } = null;
        public double? Exempt { get; set; } = null;

        /// <summary>
        /// License information
        /// </summary>
        public int? LicenseId { get; set; } = null;
        public string? LicenseDescription { get; set; } = null;
        public int? LicenseTypeId { get; set; } = null;
        public string? LicenseType { get; set; } = null;


        /// <summary>
        /// Authotization information
        /// </summary>
        public DateTime? AuthotizationDate { get; set; } = null;
        public string AuthorizedUserName { get; set; } = string.Empty;
        public string AuthorizedUserLastName { get; set; } = string.Empty;
    }


    public class FailReportUp
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
        public int ReportTypeId { get; set; } = 0;
        public int LicenseId { get; set; } = 0;
        public bool Paralyzed { get; set; } = true;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

    }

}
