using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ReportingType
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Name { get; set; } = string.Empty;
        
    }


    public class ReportingTypeFigo
    {
        public int Id { get; set; } = 0;
        public string NameReport { get; set; } = string.Empty;
        public int AccessGroupId { get; set; }
        public Boolean? IsPdfReport { get; set; }

    }

}
