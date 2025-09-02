using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class TemporyKey
    {
        public int UserId { get; set; } = 0;
        public string Login { get; set; } = string.Empty;

    }
}
