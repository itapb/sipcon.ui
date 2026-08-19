using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class GetInventoryCount 
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int SupplierId { get; set; } = 0;
        public String? Description { get; set; }
         public int? TypeId { get; set; }
         public String? Type { get; set; }
         public DateTime Created { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public String? SupplierName { get; set; }
        public DateTime? PreInventoryDate { get; set; }
        public DateTime? InventoryDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public String? StatusName { get; set; }
        public String? UserName { get; set; }
        public int? ZoneId { get; set; }
        public int? Diference { get; set; }


    }

    public class InventoryCount
    {
        [Required] public int? Id { get; set; } = 0;
        [Required] public String? Description { get; set; }
        [Required] public int? TypeId { get; set; }
        [Required] public Int32? SupplierId { get; set; } = 0;

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
        public int? ZoneId { get; set; }
        public int? Diference { get; set; }
        public bool IsSelected { get; set; } = false;





    }
    public class CountSummary
    {
        public int? ZoneId { get; set; }
         public String? Zone { get; set; }
         public Int32? LocationTotal { get; set; }
        public Int32? LocationCounted { get; set; }
         public Decimal Porcentage { get; set; }
         public String? UsersAssigned { get; set; }

    }

    public class GetCountFull : CountSummary
    {
        public bool IsSelected { get; set; } = false;
        public List<GetInventoryCountDetail>? InventoryCountDetail { get; set; } = new List<GetInventoryCountDetail>();

    }

    public class InventoryCountType
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Name { get; set; } = string.Empty;

    }
}
