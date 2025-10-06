namespace Sipcon.WebApp.Client.Models
{
    public class VehicleInvoice:  Vehicle
    {
      
        public string? CustomerLastName { get; set; }

        
        public string? Vat { get; set; }
      
        public String? Phone { get; set; }

      
        public string? Email { get; set; }

       
        public Int32? PolicyId { get; set; }

       
        public String? PolicyNumber { get; set; }

       
        public Int32? EstatusPolicyId { get; set; }
       
        public String? EstatusPolicyName { get; set; }


    }
}
