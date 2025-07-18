using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class LicenseDetail
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int LicenseId { get; set; } = 0;
        public string LicenseName { get; set; } = string.Empty;
        public int EstatusDetailId { get; set; } = 0;
        public string EstatusDetail { get; set; } = string.Empty;
        public int? ReportId { get; set; } = null;


        // The following properties are used for the vehicle details
        public int VehicleId { get; set; } = 0;
        public string VIN { get; set; } = string.Empty;
        public string EstatusVehicle { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; } = 0;

        // The following properties are used for the customer details
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;

        // The following properties are used for the dealer details
        public int DealerId { get; set; } = 0;
        public string DealerName { get; set; } = string.Empty;


    }

    public class LicenseDetailUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int LicenseId { get; set; } = 0;
        public string VIN { get; set; } = string.Empty;

    }

}
