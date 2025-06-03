using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class Policy
    {

        /// <summary> Policy </summary>
        [Required]
        public int Id { get; set; } = 0; 
        [Required]
        public bool IsActive { get; set; } = true;
        
        public string? Number { get; set; } = null;
        
        public DateTime? ActivationDate { get; set; } = null;
        
        public DateTime? LockDate { get; set; } = null;
        
        public DateTime? ExpirationDate { get; set; } = null;
        
        public int? EstatusId { get; set; } = null;
        
        public string EstatusName { get; set; } = string.Empty;


        /// <summary> Vehicle details </summary>
        [Required]
        public int? VehicleId { get; set; } = null;
        
        public string Vin { get; set; } = string.Empty;
        
        public string Plate { get; set; } = string.Empty;
        
        public string? EngineSerial { get; set; } = null;
        
        public string? Year { get; set; } = null;
        
        public string? Color { get; set; } = null;
        
        public string? BrandName { get; set; } = null;
        
        public string ModelName { get; set; } = string.Empty;
        
        public string? DealerName { get; set; } = null;
        
        public string DealerCod { get; set; } = string.Empty;
        
        public string SupplierCod { get; set; } = string.Empty;
        
        public string? SupplierName { get; set; } = null;
        
        public int? PolicyTypeId { get; set; } = null;
        
        public string Description { get; set; } = string.Empty;


        /// <summary> Customer details </summary>
        [Required]
        public int? CustomerId { get; set; } = null;
        
        public string Vat { get; set; } = string.Empty;
        
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string? Direction { get; set; } = null;
        
        public string? Phone { get; set; } = null; 
        
        
        public string? Email { get; set; } = null;


        /// <summary> Payment details </summary>
        
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;
        [Required] 
        public double? InvoiceAmount { get; set; } = 0; 
        [Required] 
        public DateTime? InvoiceDate { get; set; } = null; 
        [Required] 
        public int? PayMethodId { get; set; } = null; 
        
    }

    public class PolicyUp
    {

        /// <summary> Policy </summary>
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary> Vehicle details </summary>
        [Required]
        public int? VehicleId { get; set; } = null;

        /// <summary> Customer details </summary>
        [Required]
        public int? CustomerId { get; set; } = null;

        /// <summary> Payment details </summary>

        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;
        [Required]
        public double? InvoiceAmount { get; set; } = 0;
        [Required]
        public DateTime? InvoiceDate { get; set; } = null;
        [Required]
        public int? PayMethodId { get; set; } = null;

    }

}
