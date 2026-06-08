namespace Sipcon.WebApp.Client.Repository
{

    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Collections.Generic;
    using System.Net.Http.Json;

    public class PaymentsRepository(HttpClient http) : IPaymentService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<CurrencyType>>> GetCurrencyType()
        {
            ApiResponse <List<CurrencyType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<CurrencyType>>>($"api/Payment/GetCurrencys");

                result = (resultlist is null) ? new ApiResponse<List<CurrencyType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<CurrencyType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<CurrencyType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<CurrencyType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<PaymentType>>> GetPaymentType()
        {
            ApiResponse<List<PaymentType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<PaymentType>>>($"api/Payment/GetPaymentTypes");

                result = (resultlist is null) ? new ApiResponse<List<PaymentType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<PaymentType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<PaymentType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PaymentType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<DocumentType>>> GetDocumentType()
        {
            ApiResponse<List<DocumentType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<DocumentType>>>($"api/Payment/GetDocumentTypes");

                result = (resultlist is null) ? new ApiResponse<List<DocumentType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<DocumentType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<DocumentType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<DocumentType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<DocumentStatus>>> GetDocumentStatus()
        {
            ApiResponse<List<DocumentStatus>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<DocumentStatus>>>($"api/Payment/GetDocumentStatus");

                result = (resultlist is null) ? new ApiResponse<List<DocumentStatus>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<DocumentStatus>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<DocumentStatus>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<DocumentStatus>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<ConceptsType>>> GetDocumentConceptsType()
        {
            ApiResponse<List<ConceptsType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<ConceptsType>>>($"api/Payment/GetDocumentConcepts");

                result = (resultlist is null) ? new ApiResponse<List<ConceptsType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<ConceptsType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<ConceptsType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ConceptsType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<BankAccountsType>>> GetBankAccounts(int Idsupplier, int? IdCurrency = null)
        {
            ApiResponse<List<BankAccountsType>>? result;
            try
            {
                var url = $"api/Payment/GetBankAccounts?supplierId={Idsupplier}";
                url = IdCurrency.HasValue ? $"{url}&idCurrency={IdCurrency}" : url;
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<BankAccountsType>>>(url);

                result = (resultlist is null) ? new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<BankAccountsType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<BankAccountsType>>> GetBankOrigin()
        {
            ApiResponse<List<BankAccountsType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<BankAccountsType>>>($"api/Payment/GetBank");

                result = (resultlist is null) ? new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<BankAccountsType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<BankAccountsType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<Receivable>>> GetAccountReceivables(int IdUser, int Idsupplier, int? IdDealer
            , string TypeCode, string ConceptCode, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = ""
            , int? EstatusId = null, string DatePay = "")
        {
            ApiResponse<List<Receivable>>? result;

            try
            {
                var url = $"api/Payment/GetAccountReceivables?userId={IdUser}&supplierId={Idsupplier}&rowfrom={RowFrom}";
                url = string.IsNullOrEmpty(TypeCode) ? url : $"{url}&typeCode={TypeCode}";
                url = string.IsNullOrEmpty(ConceptCode) ? url : $"{url}&conceptCode={ConceptCode}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&statusId={EstatusId}" : url;
                url = string.IsNullOrEmpty(DatePay) ? url : $"{url}&paymentDate={DatePay}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Receivable>>>(url);

                result = (result is null) ? new ApiResponse<List<Receivable>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Receivable>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<Payment>>> GetPayments(int IdUser, int Idsupplier, int? IdDealer, int RowFrom = 0
            , string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null
            , int? PaymentId = null)
        {
            ApiResponse<List<Payment>>? result;

            try
            {
                var url = $"api/Payment/GetPayments?userId={IdUser}&supplierId={Idsupplier}&rowfrom={RowFrom}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&statusId={EstatusId}" : url;
                url = (CurrencyId.HasValue) ? $"{url}&currencyId={CurrencyId}" : url;
                url = (PaymentId.HasValue) ? $"{url}&typeId={PaymentId}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<Payment>>>(url);

                result = (result is null) ? new ApiResponse<List<Payment>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Payment>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<PaymentResumen>>> GetPaymentsStatusResumen(int IdUser, int Idsupplier, int? IdDealer, string Filter = ""
                    , string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null
                    , int? PaymentId = null)
        {
            ApiResponse<List<PaymentResumen>>? result;
            try
            {
                var url = $"api/Payment/GetPaymentStatus?userId={IdUser}&supplierId={Idsupplier}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&statusId={EstatusId}" : url;
                url = (CurrencyId.HasValue) ? $"{url}&currencyId={CurrencyId}" : url;
                url = (PaymentId.HasValue) ? $"{url}&typeId={PaymentId}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<PaymentResumen>>>(url);

                result = (result is null) ? new ApiResponse<List<PaymentResumen>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PaymentResumen>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<AccountPreview>>> GetAccountByPayment(int IdUser, int? IdPaymentDetail, int RowFrom = 0)
        {
            ApiResponse<List<AccountPreview>>? result;
            try
            {
                var url = $"api/Payment/GetAccountByPayment?userId={IdUser}&rowfrom={RowFrom}";
                url = (IdPaymentDetail.HasValue) ? $"{url}&paymentId={IdPaymentDetail}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<AccountPreview>>>(url);

                result = (result is null) ? new ApiResponse<List<AccountPreview>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AccountPreview>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }


        public async Task<ApiResponse<List<Payment>>> GetPaymentDetails(int IdUser, int? IdPaymentDetail, int RowFrom = 0)
        {
            ApiResponse<List<Payment>>? result;
            try
            {
                var url = $"api/Payment/GetPaymentDetailsById?userId={IdUser}&rowfrom={RowFrom}";
                url = (IdPaymentDetail.HasValue) ? $"{url}&paymentDetailId={IdPaymentDetail}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<Payment>>>(url);

                result = (result is null) ? new ApiResponse<List<Payment>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Payment>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }


        public async Task<ApiResponse<ActionResult>> PaymentsActions(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Payment/PostActions?userId={IdUser}", PostActions);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }

        public async Task<ApiResponse<ActionResult>> PaymentDetailsActions(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Payment/PostPayDetailsActions?userId={IdUser}", PostActions);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }

        public async Task<ApiResponse<List<byte>>> ExportAccountReceivable(int IdUser, int Idsupplier, int? IdDealer
            , string TypeCode, string ConceptCode, string Filter = "", string DateFrom = "", string DateTo = ""
            , int? EstatusId = null, string DatePay = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/Payment/ExportAccountReceivable?userId={IdUser}&supplierId={Idsupplier}";
                url = string.IsNullOrEmpty(TypeCode) ? url : $"{url}&typeCode={TypeCode}";
                url = string.IsNullOrEmpty(ConceptCode) ? url : $"{url}&conceptCode={ConceptCode}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&statusId={EstatusId}" : url;
                url = string.IsNullOrEmpty(DatePay) ? url : $"{url}&paymentDate={DatePay}";

                var response = await _http.GetAsync(url);

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = (fileContent is null) ? new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = "Error al Exportar Data.",
                    Data = []
                } : new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "",
                    Data = fileContent.ToList()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = []
                };
            }

            return result;
        }

        public async Task<ApiResponse<List<byte>>> ExportPayment(int IdUser, int Idsupplier, int? IdDealer
            ,string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? CurrencyId = null
            , int? PaymentId = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/Payment/ExportPayment?userId={IdUser}&supplierId={Idsupplier}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&statusId={EstatusId}" : url;
                url = (CurrencyId.HasValue) ? $"{url}&currencyId={CurrencyId}" : url;
                url = (PaymentId.HasValue) ? $"{url}&typeId={PaymentId}" : url;

                var response = await _http.GetAsync(url);

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = (fileContent is null) ? new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = "Error al Exportar Data.",
                    Data = []
                } : new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "",
                    Data = fileContent.ToList()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = []
                };
            }

            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreatePayment(PaymentUpdate Payment, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Payment/PostPayment?userId={IdUser}", Payment);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;

        }

        public async Task<ApiResponse<ActionResult>> UpdatePaidAmount(PostPaidAmount PaidAmount, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var response = await _http.PostAsJsonAsync($"api/Payment/PostPaidAmount?userId={IdUser}", PaidAmount);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;

        }



        public async Task<ApiResponse<ActionResult>> DeletePaymentDetails(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Payment/DeletePaymentDetails?userId={IdUser}", PostActions);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }

    }

}
