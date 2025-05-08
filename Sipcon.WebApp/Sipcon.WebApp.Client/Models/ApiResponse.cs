using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ApiResponse<T> where T : new()
    {
        public int Status { get; set; } = 200;
        public bool Processed { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int Total { get; set; } = 0;
        public T Data { get; set; } = new T();
    }
}