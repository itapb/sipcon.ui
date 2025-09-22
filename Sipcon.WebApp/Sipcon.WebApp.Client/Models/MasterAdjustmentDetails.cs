namespace Sipcon.WebApp.Client.Models
{
    public class MasterAdjustmentDetails
    {
        public Models.Adjustment? Adjustment { get; set; }
        public List<AdjustmentDetails>? Details { get; set; }
    }
}
