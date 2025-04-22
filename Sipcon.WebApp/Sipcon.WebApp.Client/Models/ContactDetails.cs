using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ContactDetails
    {
        public Contact? Contact { get; set; }
        public List<City>? Cities { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<Related>? Relateds { get; set; }

    }
}
