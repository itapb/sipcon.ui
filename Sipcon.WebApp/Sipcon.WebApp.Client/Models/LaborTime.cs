using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Sipcon.WebApp.Client.Models
{
    public class LaborTime
    {

        public int Id { get; set; } = 0;
        public int ModelId { get; set; } = 0;
        public string ModelName { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Hours { get; set; } = 0.00;
        public double Price { get; set; } = 0.00;
        public bool IsActive { get; set; } = true;

        
    }

}
