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


        public async Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<PolicyType>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<PolicyType>>>($"api/PolicyType/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}");


                result = result is null ? new ApiResponse<List<PolicyType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<PolicyType>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<PolicyType>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<PolicyType>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<PolicyType>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<List<ActionResult>>> CreatePolicyType(PolicyType PolicyType, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PolicyType> policyType = ([]);
            try
            {

                policyType.Add(PolicyType);

                var response = await _http.PostAsJsonAsync($"api/PolicyType/PostPolicyType?userId={IdUser}", policyType);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el PolicyType: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> UpdatePolicyType(PolicyType PolicyType, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PolicyType> policyType = ([]);
            try
            {

                policyType.Add(PolicyType);

                var response = await _http.PostAsJsonAsync($"api/PolicyType/PostPolicyType?userId={IdUser}", policyType);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el PolicyType: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> ActionsPolicyType(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
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

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error accion Tipo Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;

        }

        public async Task<ApiResponse<List<byte>>> ExportPolicyTypes(int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
            try
            {
                var response = await _http.GetAsync($"api/PolicyType/Export?filter={Filter}&userId={IdUser}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Tipo Polizas: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<bool>> ImportPolicyTypes(int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<bool> result;

            try
            {
                var response = await _http.PostAsync($"api/PolicyType/Import?userId={IdUser}", FormData);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Importar Tipo Polizas: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                }

                result = new ApiResponse<bool>()
                {
                    Processed = true,
                    Message = "Importacion exitosa.",
                    Data = true
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = false
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = false
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = false
                };
            }

            return result;
        }


    }

}
