using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class UserResetPassword
    {
        public int? UserId { get; set; } = 0;
        public string? Login { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? TemporaryKey { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
    }

    public class UserValidPassword
    {
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
