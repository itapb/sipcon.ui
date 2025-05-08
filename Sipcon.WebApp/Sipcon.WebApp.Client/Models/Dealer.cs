namespace Sipcon.WebApp.Client.Models
{
    public class Dealer
    {

        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int Total { get; set; } = 0;
        public string Vat{ get; set; } = string.Empty; 
        public string FirstName{ get; set; } = string.Empty;
        public string LastName{ get; set; } = string.Empty; 
        public string Address{ get; set; } = string.Empty; 
        public string Phone1{ get; set; } = string.Empty; 
        public string Phone2{ get; set; } = string.Empty; 
        public int BrandId { get; set; } = 0; 
        public string BrandName{ get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty; 
        public string Login{ get; set; } = string.Empty; 
        public string Password{ get; set; } = string.Empty;
        public string Reference{ get; set; } = string.Empty;
        public bool IsCustomer { get; set; } = false;
        public bool IsSupplier { get; set; } = false;
        public bool IsUser { get; set; } = false;
        public bool IsDealer { get; set; } = true;
        public int CityId { get; set; } = 0;
        public string CityName{ get; set; } = string.Empty; 
        public string State{ get; set; } = string.Empty;
        public bool Male { get; set; } = true;
        public DateTime Birthday{ get; set; } = DateTime.Now;
        public string Type{ get; set; } = string.Empty; 
    
        
    }
}
