using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class OrderItem
    {
        public int ItemId { get; set; }
        [Required] 
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; } 
       public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
      public string? ImageUrl { get; set; }
        public int OrderId { get; set; }
    }
}
