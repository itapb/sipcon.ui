using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class PostAction
    {     

        public int RecordId { get; set; } = 0;
        public int ModuleId { get; set; } = 0;
        public string ActionName { get; set; } = "";
        public string ActionComment { get; set; } = "";
        public int RelatedId { get; set; } = 0;
      

    }
}
