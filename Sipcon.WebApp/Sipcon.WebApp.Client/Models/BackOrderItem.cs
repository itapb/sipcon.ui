namespace Sipcon.WebApp.Client.Models
{
    public class BackOrderItem
    {
        public int? Id { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Arrival { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
