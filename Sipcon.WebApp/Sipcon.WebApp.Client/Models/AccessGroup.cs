using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class AccessGroup
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}
