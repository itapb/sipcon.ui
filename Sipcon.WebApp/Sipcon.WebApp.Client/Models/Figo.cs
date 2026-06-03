using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class FIGO_Reporte_RelacionCxC
    {
        public long Id { get; set; }
        public string? DealerName { get; set; }
        public string? Vat { get; set; }
        public string? Client { get; set; }
        public string? Phone { get; set; }
        public string? Zone { get; set; }
        public string? Occurrence { get; set; }
        public string? Document { get; set; }
        public string? IssueDate { get; set; }
        public string? DueDate { get; set; }
        public int OverdueDays { get; set; }
        public string? Currency { get; set; }
        public string? DocumentCurrency { get; set; }
        public decimal OverdueAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal ExchangeRate { get; set; }
        public string? Product { get; set; }
        public string? SerialNumber { get; set; }
        public string? ProductGroup { get; set; }
    }
}
