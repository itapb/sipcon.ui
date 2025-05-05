namespace Sipcon.WebApp.Client.Models
{
    public class WebApiResponse<T>
    {
      public int? status { get; set; }
      public bool? processed { get; set; }
      public string? message { get; set; }
      public int? total { get; set; }
      public T? data { get; set; } 
 
    }
}
