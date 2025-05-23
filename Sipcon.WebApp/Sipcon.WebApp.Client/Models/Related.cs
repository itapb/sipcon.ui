using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{  
        public class Related
        {
            [Required]
            public int? RecordId { get; set; }           
            public string? RecordName { get; set; }          
            public bool? IsSupplier { get; set; }
            public bool? IsDealer { get; set; }
            [Required]
            public bool IsRelated { get; set; }
            [Required]
            public int RelatedId { get; set; }
            public string? RelatedName { get; set; }       
            public string? Reference { get; set; }
            public override string ToString() => RelatedName!;

    }
  
}
