using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class UserResetPassword
    {
        public int UserId { get; set; } = 0;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TemporaryKey { get; set; } = string.Empty;
    }

    public class UserValidPassword
    {
        //[Required]
        //[StringLength(15, ErrorMessage = "Debe contener entre 8-10 caracteres", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        
        //[Required]
        //[Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
