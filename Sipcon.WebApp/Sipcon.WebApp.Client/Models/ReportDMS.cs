using System;
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class ReportDMS
    {

        /// <summary>
        /// Service information
        /// </summary>
        public int Id { get; set; } = 0;
        public string Srg { get; set; } = string.Empty;
        public string CodDms { get; set; } = string.Empty;
        public string CodItem { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PreApproval { get; set; } = string.Empty;
        public decimal? PaidAmount { get; set; } = 0.0M;
        public double? BaseAmount { get; set; } = 0.0;
        public int? SupplierId { get; set; } = null;
        public int? RowReference { get; set; } = null;
        public DateTime? DMSDate { get; set; } = null;
        public DateTime? PreApprovalDate { get; set; } = null;
        public DateTime? PaidAmountDate { get; set; } = null;
        public DateTime? FinalApprovalDate { get; set; } = null;
        public bool? Completed { get; set; } = null;
        public int? EstatusId { get; set; } = null;
        public string? Estatus { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        



           
           
           
           
       
    }
}
