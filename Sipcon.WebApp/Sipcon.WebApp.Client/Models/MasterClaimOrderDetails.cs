namespace Sipcon.WebApp.Client.Models
{
    public class MasterClaimOrderDetails
    {
        public ClaimPart? Claim { get; set; }
        public List<ClaimDetails>? Details { get; set; }
    }
}
