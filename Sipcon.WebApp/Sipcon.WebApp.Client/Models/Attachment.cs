using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Attachment
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string FileName { get; set; } = string.Empty;
        public int RecordId { get; set; } = 0;
        public int ModuleId { get; set; } = 0;

    }

}
