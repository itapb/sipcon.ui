using Sipcon.WebApp.Client.Models;

namespace Sipcon.WebApp.Client.Helper
{
    public class UserSession
    {
        public int UserId { get; set; }
        public int SupplierId { get; set; }
        public int DealerId { get; set; }
        public bool IsNewOrEdit { get; set; } = false;
        public bool IsFirstTime { get; set; } = true;
       
        public User UserActive { get; set; } = new User();
        public List<UserType> UserDealer { get; set; } = new();
        public List<UserType> UserSuppliers { get; set; } = new();
        public List<UserModule> UserModules { get; set; } = new();

        public string TemplateLog(string title, string message)
        {
            return $"{title} : Usuario : {UserId}  Fecha : {DateTime.Now:yyyy-MM-dd HH:mm:ss}  Mensaje : {message}";
        }
    }
}
