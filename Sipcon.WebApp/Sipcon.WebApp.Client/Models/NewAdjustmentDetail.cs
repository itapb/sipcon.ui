namespace Sipcon.WebApp.Client.Models
{
    public class NewAdjustmentDetail : Record
    {
        public int?  AdjustmentId { get; set; } = 0;
        public int?  LocationId { get; set; } = 0;
        public int?  PartId { get; set; } = 0;
        public int?  Stock { get; set; } = 0;
        public int?  ReasonId { get; set; } = 0;
        public string?  AdjustmentType { get; set; } = string.Empty;
    }
}
