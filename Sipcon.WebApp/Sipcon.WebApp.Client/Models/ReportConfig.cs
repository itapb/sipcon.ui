using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ReportConfig
    {
        public int Id { get; set; } = 0;
        public string Field { get; set; } = string.Empty;
        public string FieldType { get; set; } = string.Empty; // VARCHAR, DATE, DECIMAL
        public string ActionType { get; set; } = string.Empty; // F, A, T
        public int ReportFigoId { get; set; }
    }
}
