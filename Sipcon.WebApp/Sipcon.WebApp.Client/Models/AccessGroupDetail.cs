using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class AccessGroupDetail
    {
        public int AccessGroupId { get; set; } = 0;
        public int ModuleId { get; set; } = 0;
        public int ActionId { get; set; } = 0;
        public bool Assign { get; set; } = true;
        public string Action{ get; set; } = string.Empty;
        public string ActionDisplay { get; set; } = string.Empty;
        public string Module{ get; set; } = string.Empty;

    }


    public class AccessGroupDetailUp
    {
        public int AccessGroupId { get; set; } = 0;
        public int ModuleId { get; set; } = 0;
        public int ActionId { get; set; } = 0;
        public bool Assign { get; set; } = true;

    }
}
