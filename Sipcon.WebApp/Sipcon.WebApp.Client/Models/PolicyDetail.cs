using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PolicyDetail
    {

        [Required]
        public int Id { get; set; } = 0;
        public int? KM { get; set; } = null;
        public int? FromKm { get; set; } = null;
        public int? UpToKm { get; set; } = null;
        public string Valid { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = null;
        public DateTime? FromDate { get; set; } = null;
        public DateTime? UpToDate { get; set; } = null;
        public bool IsActive { get; set; } = true;

       
    }

}
