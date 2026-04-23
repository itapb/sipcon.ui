using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Rate 
    {
        public int? Id { get; set; } = 0;
        public decimal? NRate { get; set; }
        public DateTime DDate { get; set; }

    }
}
