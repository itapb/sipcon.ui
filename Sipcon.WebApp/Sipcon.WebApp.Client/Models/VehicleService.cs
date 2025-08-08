using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class VehicleService
    {

        /// <summary> Policy </summary>
        public int? PolicyId { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public string Number { get; set; } = string.Empty;
        public DateTime? ActivationDate { get; set; } = null;
        public DateTime? LockDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public int? EstatusPolicyId { get; set; } = null;
        public string? EstatusPolicyName { get; set; } = null;


        /// <summary> Vehicle details </summary>
        public int? Id { get; set; } = null;
        public string Vin { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string EngineSerial { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public int ColorId { get; set; } = 0;
        public string ColorName { get; set; } = string.Empty;
        public int BrandId { get; set; } = 0;
        public string BrandName { get; set; } = string.Empty;
        public int ModelId { get; set; } = 0;
        public string ModelName { get; set; } = string.Empty;
        public int PolicyTypeId { get; set; } = 0;
        public string PolicyTypeName { get; set; } = string.Empty;
        public int EstatusId { get; set; } = 0;
        public string EstatusName { get; set; } = string.Empty;

        
        /// <summary> Concesionario </summary>
        public int? DealerId { get; set; } = null;
        public string? DealerName { get; set; } = null;
        public string? dealerReference { get; set; } = null;

        
        /// <summary> Planta </summary>
        public int SupplierId { get; set; } = 0;
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierReference { get; set; } = string.Empty;


        /// <summary> Customer details </summary>
        public int? CustomerId { get; set; } = null;
        public string? Vat { get; set; } = null;
        public string? CustomerName { get; set; } = null;
        public string? CustomerLastName { get; set; } = null;
        public string? Direction { get; set; } = null;
        public string? Phone { get; set; } = null; 
        public string? Email { get; set; } = null;


        /// <summary> Payment details </summary>
        public string? InvoiceNumber { get; set; } = null;
        public double? InvoiceAmount { get; set; } = null; 
        public DateTime? InvoiceDate { get; set; } = null; 
        public int? PayMethodId { get; set; } = null;

    }
    
}
