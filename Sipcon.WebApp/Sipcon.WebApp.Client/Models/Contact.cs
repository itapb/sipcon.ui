using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Contact : Record
    {
        [Required(ErrorMessage = "Campo requerido.")]
        public string? Vat { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Campo requerido."), StringLength(maximumLength: 14, MinimumLength = 11, ErrorMessage = "Longitud requerida minino 11 o maximo 14")]   
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public Int32? BrandId { get; set; }      
        public string? BrandName { get; set; }

        [Required(ErrorMessage = "Campo requerido."), EmailAddress(ErrorMessage = "Invalida direccion de Correo.")]     
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Reference { get; set; }
      
        public bool? IsCustomer { get; set; }
      
        public bool? IsSupplier { get; set; }
        
        public bool? IsUser { get; set; }
     
        public bool? IsDealer { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public bool? IsProvider { get; set; } = false;
        public Int32? CityId { get; set; }       
        public string? CityName { get; set; }      
        public string? State { get; set; }

        public bool? Male { get; set; }
               
        public DateTime? Birthday { get; set; }

        public string? Type { get; set; }

        [Required]
        public Int32? PayMethodId { get; set; } = 0;

        [Required]
        public Int32? GroupId { get; set; } = 0;

        [Required]
        public Int32? AgentId { get; set; } = 0;
        public string? AgentName { get; set; } = string.Empty;

        [Required]
        public bool? Blocked { get; set; } = false;

        public string? FiscalName { get; set; }

    }
}
