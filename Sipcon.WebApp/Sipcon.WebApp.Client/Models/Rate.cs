using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Rate : Record
    {
        public DateTime DDate { get; set; }
        public decimal NRate { get; set; }
    }
}
