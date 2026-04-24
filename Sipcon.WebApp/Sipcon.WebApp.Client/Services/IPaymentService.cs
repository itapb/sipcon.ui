namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IPaymentService
    {
        public Task<ApiResponse<List<CurrencyType>>> GetCurrencyType();
        public Task<ApiResponse<List<PaymentType>>> GetPaymentType();
        public Task<ApiResponse<List<DocumentType>>> GetDocumentType();
        public Task<ApiResponse<List<DocumentStatus>>> GetDocumentStatus();
        public Task<ApiResponse<List<ConceptsType>>> GetDocumentConceptsType();
        public Task<ApiResponse<List<BankAccountsType>>> GetBankAccountsType(int Idsupplier);
        public Task<ApiResponse<List<Receivable>>> GetAccountReceivables(int IdUser, int Idsupplier, int? IdDealer, string TypeCode, string ConceptCode, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, string DatePay = "");
        public Task<ApiResponse<List<Payment>>> GetPayments(int IdUser, int Idsupplier, int? IdDealer, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null, int? PaymentId = null);
        public Task<ApiResponse<List<PaymentResumen>>> GetPaymentsResumen(int IdUser, int Idsupplier, int? IdDealer, string Filter = ""
                   , string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null
                   , int? PaymentId = null);
        public Task<ApiResponse<ActionResult>> PaymentsActions(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<ActionResult>> PaymentDetailsActions(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportAccountReceivable(int IdUser, int Idsupplier, int? IdDealer
            , string TypeCode, string ConceptCode, string Filter = "", string DateFrom = "", string DateTo = ""
            , int? EstatusId = null, string DatePay = "");
        public Task<ApiResponse<List<byte>>> ExportPayment(int IdUser, int Idsupplier, int? IdDealer
            , string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null
            , int? PaymentId = null);


    }
}
