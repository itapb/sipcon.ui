using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Printqueue
    {       
        public int? Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public int? RecordId { get; set; }

     
        public DateTime? Printed { get; set; }

     
        public string? ZPL { get; set; }

     
        public string PrintedDate { get; set; } = "";

     
        public string Code { get; set; } = "";

     
        public string Description { get; set; } = "";

     
        public string? Supplier { get; set; }

     
        public string CodePair { get; set; } = "";

     
        public string DescriptionPair { get; set; } = "";

     
        public int? IdPair { get; set; }

     
        public string Note { get; set; } = "";
     
        public string NotePair { get; set; } = "";

        public int? Quantity { get; set; } = 1;
    }
}
