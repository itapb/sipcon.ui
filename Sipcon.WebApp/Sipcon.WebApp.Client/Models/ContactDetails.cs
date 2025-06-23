using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sipcon.WebApp.Client.Models
{
    public class ContactDetails
    {
        public Contact? Contact { get; set; }
        public List<City>? Cities { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<Related>? Relateds { get; set; }
        public List<Models.Group>? Groups { get; set; }
        public List<PayMethod2>? PayMethods { get; set; }

    }
}
