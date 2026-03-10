namespace Sipcon.WebApp.Client.Models
{
    public class Demand
    {
            public int Id { get; set; } = 0;
            public int PartId { get; set; } = 0;
            public string InnerCode { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int Quantity { get; set; } = 0;
            public int DealerId { get; set; } = 0;
            public int ModelId { get; set; } = 0;
            public int ReasonId { get; set; } = 0;
            public DateTime Created { get; set; } = DateTime.Now;

        }
    }
