using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Contact : Record
    {
        [Required]
        public string? Vat { get; set; }
        [Required]
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public Int32? BrandId { get; set; }      
        public string? BrandName { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Reference { get; set; }
      
        public bool? IsCustomer { get; set; }
      
        public bool? IsSupplier { get; set; }
        
        public bool? IsUser { get; set; }
     
        public bool? IsDealer { get; set; }
        [Required]
        public Int32? CityId { get; set; }       
        public string? CityName { get; set; }      
        public string? State { get; set; }

        public bool Male { get; set; } = default;
               
        public DateTime? Birthday { get; set; }

        public string? Type { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
