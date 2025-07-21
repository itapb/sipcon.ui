namespace Sipcon.WebApp.Client.Repository
{
    using Microsoft.Extensions.Options;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using static System.Net.WebRequestMethods;


    public class LaborTimeRepository(HttpClient http) : ILaborTimeService
    {
        private readonly HttpClient _http = http;
        
        public async Task<ApiResponse<List<LaborTime>>> GetLaborTimes(int Idsupplier, int RowFrom = 0, string Filter = "", int? Idmodel = null )
        {
            ApiResponse<List<LaborTime>>? result;

            try
            {
                var url = $"api/LaborTime/GetAll?supplierId={Idsupplier}&irowfrom={RowFrom}";

                url = Idmodel is null ? url : $"{url}&modelId={Idmodel}";
                
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<LaborTime>>>(url);

                result = (result is null) ? new ApiResponse<List<LaborTime>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<LaborTime>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<LaborTime>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<LaborTime>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateLaborTime(LaborTime LaborTime, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<LaborTime> laborTimes = ([]);
            try
            {
                
                laborTimes.Add(LaborTime);

                var response = await _http.PostAsJsonAsync($"api/LaborTime/PostLaborTime?userId={IdUser}", laborTimes);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Post LaborTime: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<ActionResult>>> UpdateLaborTime(LaborTime LaborTime, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<LaborTime> laborTimes  = ([]);
            try
            {
                laborTimes.Add(LaborTime);

                var response = await _http.PostAsJsonAsync($"api/LaborTime/PostLaborTimes?userId={IdUser}", laborTimes);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Post LaborTime: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
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

        public async Task<ApiResponse<List<ActionResult>>> DeleteLaborTimes(List<PostAction> PostActions, int IdUser)
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


                var response = await _http.PostAsJsonAsync($"api/LaborTime/Delete_LaborTime?userId={IdUser}", PostActions, options);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Post LaborTime: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<byte>>> ExportLaborTimes(int Idmodel, int Idsupplier, string Filter = "")
        {
            ApiResponse<List<byte>> result; 
            string fileUrl = string.Empty;
            try
            {

                var url = $"api/LaborTime/Export?modelId={Idmodel}&supplierId={Idsupplier}";

                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                var response = await _http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = false,
                        Message = "Error al Exportar ",
                        Data = []
                    };
                }
                else {
                    var fileContent = await response.Content.ReadAsByteArrayAsync();
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = true,
                        Message = "Exportación exitosa.",
                        Data = fileContent.ToList()
                    };
                }

                
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

        public async Task<ApiResponse<bool>> ImportLaborTimes(int IdUser, int Idmodel, MultipartFormDataContent FormData )
        {
            ApiResponse<bool> result;
            
            try
            {
                var response = await _http.PostAsync($"api/LaborTime/Import?userId={IdUser}&modelId={Idmodel}", FormData);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = false,
                        Message = "Error al Importar.",
                        Data = false
                    };
                }
                else
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = true,
                        Message = "Importacion exitosa.",
                        Data = true
                    };
                }

                    
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
