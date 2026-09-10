using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Printer
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int? IdSupplier { get; set; }

        public bool? BDefault { get; set; }
    }
}