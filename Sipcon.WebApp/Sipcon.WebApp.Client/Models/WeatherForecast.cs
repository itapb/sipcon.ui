using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{    
    public class WeatherForecast
    {
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
   
        public int TemperatureC { get; set; }  = 32;
        [Required]
        public string? Summary { get; set; } 
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public bool IsSelected { get; set; } = false;
    }
}
