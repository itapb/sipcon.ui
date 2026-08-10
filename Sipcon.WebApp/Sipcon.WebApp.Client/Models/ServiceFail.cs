namespace Sipcon.WebApp.Client.Models
{
    public class ServiceFail
    {

        public Int32? ReportId { get; set; }
        public Int32? CustomerId { get; set; }
        public String? Customer { get; set; }
        public String? Vin { get; set; }
        public Boolean? Paralyzed { get; set; }
        public Int32? VehicleId { get; set; }

    }

    public class VehicleInvoiceList
    {
        public Int32? VehicleId { get; set; }
        public Int32? CustomerId { get; set; }
        public String? Customer { get; set; }
        public String? Vin { get; set; }
        public String? Model { get; set; }
        public int? Year { get; set; }
    }
}
