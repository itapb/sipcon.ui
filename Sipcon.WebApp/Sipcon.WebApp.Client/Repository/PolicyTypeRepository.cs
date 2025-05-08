namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;


    public class PolicyTypeRepository(HttpClient http) : IPolicyTypeService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<PolicyType>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<PolicyType>>>($"api/PolicyType/GetAll?rowFrom={RowFrom}&userId={IdUser}");


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

        public async Task<bool> CreatePolicyType(PolicyType PolicyType, int IdUser)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/PolicyType/PostPolicyType", PolicyType);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el modelo: {response.StatusCode} - {response.ReasonPhrase}");
                }

                bool? createdModel = await response.Content.ReadFromJsonAsync<bool>();

                if (createdModel == null)
                {
                    throw new Exception("El servidor devolvió una respuesta vacía.");
                }

                return (bool)createdModel;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Error al realizar la solicitud HTTP: " + httpEx.Message, httpEx);
            }
            catch (NotSupportedException notSupportedEx)
            {
                throw new Exception("El formato de la respuesta no es compatible: " + notSupportedEx.Message, notSupportedEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado: " + ex.Message, ex);
            }
        }
        public async Task<bool> UpdatePolicyType(PolicyType PolicyType, int IdUser)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/PolicyType/PostPolicyType", PolicyType);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el modelo: {response.StatusCode} - {response.ReasonPhrase}");
                }

                bool? createdModel = await response.Content.ReadFromJsonAsync<bool>();

                if (createdModel == null)
                {
                    throw new Exception("El servidor devolvió una respuesta vacía.");
                }

                return (bool)createdModel;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Error al realizar la solicitud HTTP: " + httpEx.Message, httpEx);
            }
            catch (NotSupportedException notSupportedEx)
            {
                throw new Exception("El formato de la respuesta no es compatible: " + notSupportedEx.Message, notSupportedEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado: " + ex.Message, ex);
            }

        }
      
    }

}
