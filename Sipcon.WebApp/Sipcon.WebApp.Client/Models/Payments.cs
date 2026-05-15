using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sipcon.WebApp.Client.Models
{
    public class CurrencyType: BaseType
    {
        
    }
    public class PaymentType : BaseType
    {
        
    }
    public class DocumentType : BaseType
    {
        public string Code { get; set; } = string.Empty;
    }
    public class ConceptsType : BaseType
    {
        public string Code { get; set; } = string.Empty;
        public bool IsExclusive { get; set; } = false;
    }
    public class DocumentStatus : BaseType
    {
        public string Display { get; set; } = string.Empty;
    }
    public class BankAccountsType : BaseType
    {
        public string Code { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
    }
    public class Receivable 
    {
        public int SupplierId { get; set; }
        public int? DealerId { get; set; } = null;
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string ConceptCode { get; set; } = string.Empty;
        public string ConceptName { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
        public DateTime? DocumentDueDate { get; set; } = null;
        public DateTime? DateRate { get; set; } = null;
        public double? Amount { get; set; } = null;
        public double? AmountBs { get; set; } = null;
        public double? Balance { get; set; } = null;
        public double? BalanceBs { get; set; } = null;
        public double? Rate { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public string StatusName { get; set; } = string.Empty;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsSelected { get; set; } = false;
      
       
    }


    public class PaymentResumen
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }

    }
    public class Payment
    {
        public List<AccountPreview> AccountPreview { get; set; } = new List<AccountPreview>();
        public int PaymentId { get; set; }
        public int SupplierId { get; set; }
        public int DealerId { get; set; } 
        public string DealerName { get; set; } = string.Empty;
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
        public int TypeId { get; set; } 
        public string TypeName { get; set; } = string.Empty;
        public int? BankId { get; set; }  = null;
        public string BankName { get; set; } = string.Empty;
        public int? AccountId { get; set; } = null;
        public string AccountNumber { get; set; } = string.Empty;
        public int? BankOriginId { get; set; } = null;
        public string BankOriginName { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public DateTime DateRate { get; set; }
        public DateTime? Date { get; set; } = null;
        public double? Amount { get; set; } = null;
        public double? AmountBs { get; set; } = null;
        public double? Rate { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public string StatusName { get; set; } = string.Empty;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsSelected { get; set; } = false;

    }
    public class PaymentUpdate
    {
        public int PaymentId { get; set; }
        public int SupplierId { get; set; }
        public int DealerId { get; set; } 
        public int? CurrencyId { get; set; } = null;
        public int? TypeId { get; set; } = null;
        public string Reference { get; set; } = string.Empty;
        public int? AccountId { get; set; } = null;
        public int? BankOriginId { get; set; } = null;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Date { get; set; } = null;
        public double? Amount { get; set; } = null;
       

        public List<DocumentUpdate> Settlements { get; set; } = new List<DocumentUpdate>();

    }

    public class DocumentUpdate
    {
        public int DocumentId { get; set; } = 0;
        public double Rate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateRate { get; set; }

    }

    public class AccountPreview
    {
        public int Id { get; set; } = 0;
        public int PaymentId { get; set; } = 0;
        public string Number { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
        
        public double? Rate { get; set; } = null;
        public DateTime? DateRate { get; set; } = null;
        public double? Amount { get; set; } = null;
        public double? AmountBs { get; set; } = null;
        public string ConceptName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;

    }


}
