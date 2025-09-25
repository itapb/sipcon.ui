namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using System.Net.Http.Json;



    public class PolicyRepository(HttpClient http) : IPolicyService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Policy>>> GetPolicys(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Policy>>? result;
            try
            {
                var url = $"api/Policy/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Policy>>>(url);

                result = result is null ? new ApiResponse<List<Policy>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Policy>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<Policy>> GetPolicy(int IdPolicy, int IdUser) 
        {
            ApiResponse<Policy>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Policy>>($"api/Policy/GetOne?policyId={IdPolicy}&userId={IdUser}");

                result = (result is null) ? new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<Policy>> GetPolicyBy(string Search, int IdUser, SearchByEnum SearchBy)
        {
            ApiResponse<Policy>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Policy>>($"api/Policy/GetOneBy?userId={IdUser}&filter={Search}&filterBy={(int)SearchBy}");

                result = (result is null) ? new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreatePolicy(Policy Policy, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var _policy = new PolicyUp()
                {
                    Id = Policy.Id,
                    IsActive = Policy.IsActive,
                    VehicleId = Policy.VehicleId,
                    CustomerId = Policy.CustomerId,
                    InvoiceNumber = Policy.InvoiceNumber,
                    InvoiceAmount = Policy.InvoiceAmount,
                    InvoiceDate = Policy.InvoiceDate,
                    PayMethodId = Policy.PayMethodId
                };

                var response = await _http.PostAsJsonAsync($"api/Policy/PostPolicy?userId={IdUser}", _policy);

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

        public async Task<ApiResponse<ActionResult>> UpdatePolicy(Policy Policy, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var _policy = new PolicyUp()
                { 
                    Id              = Policy.Id,
                    IsActive        = Policy.IsActive,
                    VehicleId       = Policy.VehicleId,
                    CustomerId      = Policy.CustomerId,
                    InvoiceNumber   = Policy.InvoiceNumber,
                    InvoiceAmount   = Policy.InvoiceAmount,
                    InvoiceDate     = Policy.InvoiceDate,
                    PayMethodId     = Policy.PayMethodId
                };

                var response = await _http.PostAsJsonAsync($"api/Policy/PostPolicy?userId={IdUser}", _policy);

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

        public async Task<ApiResponse<ActionResult>> ActionsPolicy(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Policy/PostActions?userId={IdUser}", PostActions);
               
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

        public async Task<ApiResponse<List<PolicyDetail>>> GetOnePolicyDetails(int IdPolicy, int Km, DateTime DateService)
        {
            ApiResponse<List<PolicyDetail>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<PolicyDetail>>>($"api/Policy/GetOnePolicyDetails?policyId={IdPolicy}&km={Km}&date={DateService.ToString("yyyy/MM/dd")}");

                result = (result is null) ? new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<PolicyDetail>>> GetLogPolicyDetails(int IdPolicy)
        {
            ApiResponse<List<PolicyDetail>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<PolicyDetail>>>($"api/Policy/GetLogPolicyDetails?policyId={IdPolicy}");

                result = (result is null) ? new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<byte>>> ExportPolicys(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                var url = $"api/Policy/Export?supplierId={IdSupplier}&userId={IdUser}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

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

        public async Task<ApiResponse<List<byte>>> ExportPdfPolicy(int IdUser, int IdPolicy )
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var response = await _http.GetAsync($"api/Policy/ExportPdf?policyId={IdPolicy}&userId={IdUser}");
               
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

      

    }

}
