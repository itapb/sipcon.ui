namespace Sipcon.WebApp.Client.Models
{
    public class NewClaimOrderDetails : Record
    {
        public int? ClaimId { get; set; } = 0;
        public int? PartId { get; set; } = 0;
        public int? Quantity { get; set; } = 0;
        public int? ReplacementPartId { get; set; } = 0;
        public int? ReasonId { get; set; } = 0;


        public string?  PartInnerCode { get; set; }
        public string?  PartName { get; set; }
        public string? RemplacemetInnerCode { get; set; }
        public string?  ReplacemetName { get; set; }
        public string? ReasonDescription  { get; set; }
        public string? statusName { get; set; }
        public string? Comment { get; set; }
        public int?  iApproved { get; set; }

    }
}
