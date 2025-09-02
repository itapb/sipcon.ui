namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using System.Net.Http.Json;



    public class PolicyRepository(HttpClient http) : IPolicyService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Policy>>> GetPolicys(int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Policy>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<Policy>>>($"api/Policy/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}");


                result = result is null ? new ApiResponse<List<Policy>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Policy>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Policy>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Policy>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error al crear el Policy: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error al crear el Policy: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error accion Tipo Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<List<byte>>> ExportPolicys(int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                
                var response = await _http.GetAsync($"api/Policy/Export?filter={Filter}&userId={IdUser}");
                    
                    
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "Exportación exitosa.",
                    Data = fileContent.ToList()
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = []
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = []
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

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "Exportación exitosa.",
                    Data = fileContent.ToList()
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = []
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = []
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<PolicyDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

    }

}
