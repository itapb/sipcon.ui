using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class FailReportDetail
    {
        public int Id { get; set; } = 0;
        public int ServiceId { get; set; } = 0; 
        public string? ServiceName { get; set; } = null;
        public int ItemId { get; set; } = 0;
        public string ItemName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int EstatusId { get; set; } = 0;
        public string EstatusName { get; set; } = string.Empty;
        public double? Quantity { get; set; } = null;
        public double? UnitPrice { get; set; } = null;
        public double Price { get; set; } = 0;
        public string Serial { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public bool IsExternal { get; set; } = false;
        public bool IsTax { get; set; } = false;
        public bool IsActive { get; set; } = true;
  
    }


    public class FailReportDetailUp
    {
        public int Id { get; set; } = 0;
        public int ServiceId { get; set; } = 0;
        public int ItemId { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        public double Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public bool IsExternal { get; set; } = true;
        public bool IsTax { get; set; } = true;
        public bool IsActive { get; set; } = true;

    }

}
