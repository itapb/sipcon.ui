using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public User Users { get; set; } = new User();
        public List<UserType> Suppliers { get; set; } = new List<UserType>();
        public List<UserType> Dealers { get; set; } = new List<UserType>();
        public List<UserModule> Modules { get; set; } = new List<UserModule>();
    }

    public class User
    {
        public string Login { get; set; } =  string.Empty; 
        public string Name { get; set; } =  string.Empty;
        public string LastName { get; set; } =  string.Empty;
        public string Vat { get; set; } =  string.Empty; 
        public int Id { get; set; } =  0;
        public bool IsActive { get; set; } = true;

    }

    public class UserType
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;

    }

    public class UserModule
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string? ActionName { get; set; } = null;
        public string? ActionDisplay { get; set; } = null;
        public List<UserAction> Actions { get; set; } = new List<UserAction>();

    }

    public class UserAction
    {
        public int ModuleId { get; set; } = 0;
        public int ActionId { get; set; } = 0;
        public string ActionName { get; set; } = string.Empty;

    }
}
