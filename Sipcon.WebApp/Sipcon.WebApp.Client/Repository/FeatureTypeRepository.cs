namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class FeatureTypeRepository(HttpClient http) : IFeatureTypeService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<FeatureType>>> GetFeatureTypes(
            int userId, int supplierId, int dealerId,
            int rowFrom = 0, string filter = "", bool? active = null)
        {
            ApiResponse<List<FeatureType>>? result;
            try
            {
                var url = $"api/FeatureType/GetAll?userId={userId}&supplierId={supplierId}&dealerId={dealerId}&rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<FeatureType>>>(url);
                result ??= new ApiResponse<List<FeatureType>> { Processed = false, Message = "La respuesta del servidor no contiene datos." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FeatureType>> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<FeatureType>> GetFeatureType(int featureTypeId, int userId)
        {
            ApiResponse<FeatureType>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<FeatureType>>(
                    $"api/FeatureType/GetOne?featureTypeId={featureTypeId}&userId={userId}");
                result ??= new ApiResponse<FeatureType> { Processed = false, Message = "La respuesta del servidor no contiene datos." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<FeatureType> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> SaveFeatureType(FeatureType featureType, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/FeatureType/Post?userId={userId}", new List<FeatureType> { featureType });
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult> { Processed = false, Message = "El servidor devolvió una respuesta vacía." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> ActionsFeatureType(List<PostAction> postActions, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy     = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition   = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented            = true
                };
                var response = await _http.PostAsJsonAsync(
                    $"api/FeatureType/PostActions?userId={userId}", postActions, options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult> { Processed = false, Message = "El servidor devolvió una respuesta vacía." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<List<byte>>> ExportFeatureTypes(
            int userId, int supplierId, int dealerId,
            string filter = "", bool? active = null)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/FeatureType/Export?userId={userId}&supplierId={supplierId}&dealerId={dealerId}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                var response    = await _http.GetAsync(url);
                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = fileContent is null || fileContent.Length == 0
                    ? new ApiResponse<List<byte>> { Processed = false, Message = "Error al exportar data.", Data = [] }
                    : new ApiResponse<List<byte>> { Processed = true,  Message = string.Empty, Data = fileContent.ToList() };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message), Data = [] };
            }
            return result;
        }
    }
}
