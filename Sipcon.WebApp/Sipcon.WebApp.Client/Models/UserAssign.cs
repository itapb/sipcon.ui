using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class UserAssign
    {
        public int Id { get; set; } = 0;
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Vat { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }

}
