using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class City : Record
    {

        public string? Name { get; set; }
        public string? MunicipalityName { get; set; }
        public string? StateName { get; set; }

        public int? MunicipalityId { get; set; }
        public int? StateId { get; set; }
    }

}
