namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ModelRepository(HttpClient http) : IModelService
    {
        private readonly HttpClient _http = http;

        
        public async Task<ApiResponse<List<Model>>> GetModels(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Model>>? result;
            try
            {
                var url = $"api/Model/GetAll?supplierId={IdSupplier}&rowFrom={RowFrom}&userId={IdUser}";    
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                result = await _http.GetFromJsonAsync<ApiResponse<List<Model>>>(url);

                result = (result is null) ? new ApiResponse<List<Model>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Model>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Model>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Model>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }

        public async Task<ApiResponse<Model>> GetModel(int IdModel, int IdUser) 
        {
            ApiResponse<Model>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Model>>($"api/Model/GetOne?ModelId={IdModel}");

                result = (result is null) ? new ApiResponse<Model>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Model>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Model>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Model>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreateModel(Model Model, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<Model> modelList = ([]);
            try
            {

                modelList.Add(Model);

                var response = await _http.PostAsJsonAsync($"api/Model/PostModels?userId={IdUser}", modelList);

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

        public async Task<ApiResponse<ActionResult>> UpdateModel(Model Model, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<Model> modelList = ([]);
            try
            {

                modelList.Add(Model);


                var response = await _http.PostAsJsonAsync($"api/Model/PostModels?userId={IdUser}", modelList);

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


        public async Task<ApiResponse<ActionResult>> ActionsModel(List<PostAction> PostActions, int IdUser)
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


                var response = await _http.PostAsJsonAsync($"api/Model/PostActions?userId={IdUser}", PostActions, options);

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

        public async Task<ApiResponse<List<byte>>> ExportModels(int IdSupplier, int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
            try
            {
                var url = $"api/Model/Export?supplierId={IdSupplier}&userId={IdUser}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&_filter={Filter}";

                var response = await _http.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Exportar Modelos: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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


        public async Task<ApiResponse<bool>> ImportModels(int IdSupplier, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<bool> result;

            try
            {
                var url = $"api/Model/Import?supplierId={IdSupplier}&userId={IdUser}";

                var response = await _http.PostAsync(url, FormData);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Importar Modelo: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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
