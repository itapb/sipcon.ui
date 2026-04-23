using System.ComponentModel.DataAnnotations;

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
        public double? Amount { get; set; } = null;
        public double? Balance { get; set; } = null;
        public double? Rate { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public string StatusName { get; set; } = string.Empty;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsSelected { get; set; } = false;
      
       
    }

    public class Payment
    {
        public PaymentDetail PaymentDetail { get; set; } = new PaymentDetail();
        public List<AccountPreview> AccountPreview { get; set; } = new List<AccountPreview>();
    }

    public class PaymentResumen
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }

    }
    public class PaymentDetail
    {
        public int PaymentId { get; set; }
        public int SupplierId { get; set; }
        public int? DealerId { get; set; } = null;
        public string DealerName { get; set; } = string.Empty;
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
        public int TypeId { get; set; } 
        public string TypeName { get; set; } = string.Empty;
        public int BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public int? BankOriginId { get; set; } = null;
        public string BankOriginName { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public DateTime DateRate { get; set; }
        public DateTime? Date { get; set; } = null;
        public double? Amount { get; set; } = null;
        public double? Rate { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public string StatusName { get; set; } = string.Empty;
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;

    }

    public class AccountPreview
    {
        public int Id { get; set; } = 0;
        public int PaymentId { get; set; } = 0;
        public string Number { get; set; } = string.Empty;
        //public DateTime DocumentDate { get; set; }
        public string DocumentDate { get; set; } = string.Empty;
        public double? Amount { get; set; } = null;
        public string ConceptName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;

    }


}
