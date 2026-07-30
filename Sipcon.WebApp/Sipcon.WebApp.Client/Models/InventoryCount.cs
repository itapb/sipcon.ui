using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class InventoryCount : Record
    {
         public String? Description { get; set; }
         public int? TypeId { get; set; }
         public String? Type { get; set; }
         public Int32? SupplierId { get; set; }
         public DateTime Created { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public String? SupplierName { get; set; }
        public DateTime? PreInventoryDate { get; set; }
        public DateTime? InventoryDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public String? StatusName { get; set; }
        public String? UserName { get; set; }

    }

    public class GetInventoryCountDetail : Record
    {

        public int? InventoryId { get; set; }
        public int? CountId { get; set; }
        public int? LocationId { get; set; }
        public int? PartId { get; set; }
        public int? QuantityOld { get; set; }
        public int? QuantityNew { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? CountDate { get; set; }
        public String? StatusName { get; set; }
        public String? UserName { get; set; }
        public String? Location { get; set; }
        public String? Zone { get; set; }
        public String? InnerCode { get; set; }
        public String? PartName { get; set; }

    }


    public class InventoryCountType
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Name { get; set; } = string.Empty;

    }
}
