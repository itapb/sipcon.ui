using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class License
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int SupplierId { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int EstatusId { get; set; } = 0;
        public string EstatusName { get; set; } = string.Empty;
        public int? TypeId { get; set; } = null;
        public string Type { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; } = null;

    }

    public class LicenseUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int SupplierId { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int TypeId { get; set; } = 0;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

    }

}
