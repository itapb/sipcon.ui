using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Part : Record
    {


        [Required]
        public string? InnerCode { get; set; } = string.Empty;

        [Required]
        public string? MasterCode { get; set; } = string.Empty;

        public string? BarCode { get; set; } = string.Empty;

        public string? AlterCode { get; set; } = string.Empty;

        public string? ReplacementCode { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? TypeId { get; set; } = 1;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? FamilyId { get; set; } = 1;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? SubFamilyId { get; set; } = 1;

        [Required]
        public decimal? Price { get; set; } = decimal.Zero;

        [Required]
        public decimal? Cost { get; set; } = decimal.Zero;

        [Required]
        public decimal? Discount { get; set; } = decimal.Zero;

        [Required]
        public decimal? Weight { get; set; } = decimal.Zero;

        [Required]
        public string? Size { get; set; } = string.Empty;

        [Required]
        public string? Rating { get; set; } = string.Empty;

        [Required]
        public Int32? MinSale { get; set; } = 1;

        [Required]
        public Int32? Packing { get; set; } = 1;

        [Required]
        public bool? Sell { get; set; } = true;

        [Required]
        public bool? Purchase { get; set; } = true;

        [Required]
        public bool? Warranty { get; set; } = true;

        [Required]
        public bool? License { get; set; } = false;

        [Required]
        public bool? Original { get; set; } = true;

        [Required]
        public bool? Serializable { get; set; } = false;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? SupplierId { get; set; } = 1;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? BrandId { get; set; } = 1;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? UmId { get; set; } = 1;

        [Required]
        [Range(1, int.MaxValue)]
        public Int32? TaxId { get; set; } = 1;

        public string? TypeName { get; set; } = string.Empty;
        public string? FamilyName { get; set; } = string.Empty;
        public string? SubFamilyName { get; set; } = string.Empty;
        public string? TaxName { get; set; } = string.Empty;
        public string? UmName { get; set; } = string.Empty;

        public string? BrandName { get; set; } = string.Empty;
        public string? SupplierReference { get; set; } = string.Empty;

        public Int32? Stock { get; set; } = 0;
        public Int32? Available { get; set; } = 0;
        public string? AlterDescription { get; set; } = string.Empty;
        public Int32? UseQty { get; set; } = 0;
        

    }
}
