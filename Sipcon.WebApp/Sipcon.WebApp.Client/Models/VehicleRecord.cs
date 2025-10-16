using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class VehicleRecord
    {
        public VehicleHistory Vehicle { get; set; } = new VehicleHistory();
        public CustomerHistory Customer { get; set; } = new CustomerHistory();
        public PolicyHistory Policy { get; set; } = new PolicyHistory();
        public List<ServiceHistory>  ServiceRecord { get; set; } = new List<ServiceHistory>();

        public List<EstatusHistory> EstatusRecord { get; set; } = new List<EstatusHistory>();

    }
    public class VehicleHistory
    {
        public string Vin { get; set; } = string.Empty;
        public string EngineSerial { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public int ColorId { get; set; } = 0;
        public string ColorName { get; set; } = string.Empty;
        public int ModelId { get; set; } = 0;
        public string ModelName { get;  set; } = string.Empty;
        public int BrandId { get; set; } = 0;
        public string BrandName { get;  set; } = string.Empty;
        public int Year { get; set; } = 0;
        public int SupplierId { get; set; } = 0;
        public string SupplierName { get;  set; } = string.Empty;
        public int DealerId { get; set; } = 0;
        public string DealerName { get;  set; } = string.Empty;
        public int CustomerId { get; set; } = 0;
        public string? CustomerName { get; set; } = null;
        public int EstatusId { get; set; } = 0;
        public string EstatusName { get; set; } = string.Empty;
        public string DealerReference { get; set; } = string.Empty; 
        public string SupplierReference { get; set; } = string.Empty; 
        public int PolicyTypeId { get; set; } = 0;
        public string PolicyTypeName { get; set; } = string.Empty;
        public int? Lastkm { get; set; } = null;
        public int? RowReference { get; set; } = null;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }

    public class CustomerHistory
    {
        public int CustomerId { get; set; } = 0;
        public string? CustomerName { get; set; } = string.Empty;
        public string? CustomerLastName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Direction { get; set; } = string.Empty;
        public string? Vat { get; set; } = string.Empty;
        
    }

    public class PolicyHistory
    {
        public int? PolicyId { get; set; } = 0;
        public string Number { get; set; } = string.Empty;
        public DateTime? ActivationDate { get; set; } = null;
        public DateTime? LockDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public string? InvoiceNumber { get; set; } = string.Empty;
        public double? InvoiceAmount { get; set; } = 0;
        public DateTime? InvoiceDate { get; set; } = null;
        public int? PayMethodId { get; set; } = 0;
        public string? payMethod { get; set; } = string.Empty;
        public int? EstatusPolicyId { get; set; } = null;
        public string? EstatusPolicyName { get; set; } = string.Empty;

    }

    public class ServiceHistory
    {
        public int ReportId { get; set; } = 0;
        public int ServiceTypeId { get; set; } = 0;
        public string ServiceTypeName { get; set; } = string.Empty;
        public int ReportTypeId { get; set; } = 0;
        public string ReportTypeName { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime? ServiceDate { get; set; } = null;
        public string DealerServiceName { get; set; } = string.Empty;
        public string DealerServiceCod { get; set; } = string.Empty;
        public string SrgNumber { get; set; } = string.Empty;
        public int Km { get; set; } = 0;
        public double? InvoiceAmount { get; set; } = 0;
        public int EstatusId { get; set; } = 0;
        public string EstatusName { get; set; } = string.Empty;

        //"date": "2025-10-12T22:05:23.387"

    }

    public class EstatusHistory
    {
        public int EstatusId { get; set; } = 0;
        public string Estatus { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = null;

    }

}
