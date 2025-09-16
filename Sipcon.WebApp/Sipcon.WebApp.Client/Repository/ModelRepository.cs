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

        public async Task<ApiResponse<ActionResult>> ImportModels(int IdSupplier, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var url = $"api/Model/Import?supplierId={IdSupplier}&userId={IdUser}";

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
