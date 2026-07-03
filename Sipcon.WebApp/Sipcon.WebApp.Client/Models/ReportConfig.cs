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
        public List<FilterOptionDto> Options { get; set; } = new();
    }


    public class FilterOptionDto
    {
        public int ReportFigoId { get; set; }
        public int FilterReportId { get; set; } // El ID del filtro al que pertenece
        public int FilterOptionId { get; set; }
        public string Name { get; set; }        // "DOLAR"
        public string Value { get; set; }       // "USD"
    }
}
