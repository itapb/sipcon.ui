namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class PolicyTypeRepository(HttpClient http) : IPolicyTypeService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? Idbrand = null)
        {
            ApiResponse<List<PolicyType>>? result;

            try
            {
                var url = $"api/PolicyType/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = (Idbrand.HasValue && Idbrand.Value > 0) ? $"{url}&brandId={Idbrand}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<PolicyType>>>(url);


                result = result is null ? new ApiResponse<List<PolicyType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PolicyType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<PolicyType>> GetPolicyType(int IdPolicyType, int IdUser) 
        {
            ApiResponse<PolicyType>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<PolicyType>>($"api/PolicyType/GetOne?policyTypeId={IdPolicyType}&userId{IdUser}");

                result = (result is null) ? new ApiResponse<PolicyType>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<PolicyType>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreatePolicyType(PolicyType PolicyType, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PolicyType> policyType = ([]);
            try
            {

                policyType.Add(PolicyType);

                var response = await _http.PostAsJsonAsync($"api/PolicyType/PostPolicyType?userId={IdUser}", policyType);

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

        public async Task<ApiResponse<ActionResult>> UpdatePolicyType(PolicyType PolicyType, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PolicyType> policyType = ([]);
            try
            {

                policyType.Add(PolicyType);

                var response = await _http.PostAsJsonAsync($"api/PolicyType/PostPolicyType?userId={IdUser}", policyType);

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

        public async Task<ApiResponse<ActionResult>> ActionsPolicyType(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                var response = await _http.PostAsJsonAsync($"api/PolicyType/PostActions?userId={IdUser}", PostActions, options);
                
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

        public async Task<ApiResponse<List<byte>>> ExportPolicyTypes(int IdSupplier, int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            
            try
            {
                var url = $"api/PolicyType/Export?supplierId={IdSupplier}&userId={IdUser}";
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

        public async Task<ApiResponse<ActionResult>> ImportPolicyTypes(int IdSupplier, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var url = $"api/PolicyType/Import?supplierId={IdSupplier}&userId={IdUser}";

                var response = await _http.PostAsync(url, FormData);
                
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
