namespace Sipcon.WebApp.Client.Models
{
    public class MasterGuideDetails
    {
        public Pages.Mobile.Models.Guide? Guide { get; set; }
        public List<Models.GuideDetails>? GuideDetails { get; set; }
    }
}
