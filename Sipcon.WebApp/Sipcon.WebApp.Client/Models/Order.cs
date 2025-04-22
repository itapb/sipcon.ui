namespace Sipcon.WebApp.Client.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

    }
}
