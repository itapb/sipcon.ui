using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ClaimDetails  : Record
    {
        [Required]
        public int? ClaimId { get; set; }

        [Required]
        public int? PartId { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int? ReplacementPartId { get; set; }

        [Required]
        public int? ReasonId { get; set; }


        public string? PartInnerCode { get; set; }


        public string? PartName { get; set; }


        public string? RemplacemetInnerCode { get; set; }


        public string? ReplacemetName { get; set; }


        public string? ReasonDescription { get; set; }


        public string? StatusName { get; set; }


        public string? Comment { get; set; }


        public int? IApproved { get; set; }

        public decimal? SubTotal { get; set; }
    }
}
