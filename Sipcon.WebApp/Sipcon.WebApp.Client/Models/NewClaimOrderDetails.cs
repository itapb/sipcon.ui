namespace Sipcon.WebApp.Client.Models
{
    public class NewClaimOrderDetails : Record
    {
        public int? ClaimOrderId { get; set; } = 0;
        public int? PartId { get; set; } = 0;
        public int? Quantity { get; set; } = 0;
        public int? ReasonId { get; set; } = 0;
    
    }
}
