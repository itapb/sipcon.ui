using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Contact : Record
    {
        [Required(ErrorMessage = "Rif es requerido.")]
        public string? Vat { get; set; }
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Direccion es requerido.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Telefono 1 es requerido.")]
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public Int32? BrandId { get; set; }      
        public string? BrandName { get; set; }
        [Required(ErrorMessage = "Email es requerido.")]
        [EmailAddress(ErrorMessage = "Invalida direccion de email.")]
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Reference { get; set; }
      
        public bool? IsCustomer { get; set; }
      
        public bool? IsSupplier { get; set; }
        
        public bool? IsUser { get; set; }
     
        public bool? IsDealer { get; set; }
        [Required(ErrorMessage = "Ciudad es requerida.")]
        public Int32? CityId { get; set; }       
        public string? CityName { get; set; }      
        public string? State { get; set; }

        public bool Male { get; set; } = default;
               
        public DateTime? Birthday { get; set; }

        public string? Type { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
