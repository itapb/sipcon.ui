namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class FeatureRepository(HttpClient http) : IFeatureService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<Feature>>> GetFeatures(
            int userId, int supplierId, int? dealerId,
            int rowFrom = 0, string filter = "", bool? active = null)
        {
            ApiResponse<List<Feature>>? result;
            try
            {
                var url = $"api/Feature/GetAll?userId={userId}&supplierId={supplierId}&rowFrom={rowFrom}";
                if (dealerId.HasValue)             url += $"&dealerId={dealerId.Value}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Feature>>>(url);
                result ??= new ApiResponse<List<Feature>> { Processed = false, Message = "La respuesta del servidor no contiene datos." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Feature>> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<Feature>> GetFeature(int featureId, int userId)
        {
            ApiResponse<Feature>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Feature>>(
                    $"api/Feature/GetOne?featureId={featureId}&userId={userId}");
                result ??= new ApiResponse<Feature> { Processed = false, Message = "La respuesta del servidor no contiene datos." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Feature> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> SaveFeature(Feature feature, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/Feature/Post?userId={userId}", new List<Feature> { feature });
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult> { Processed = false, Message = "El servidor devolvió una respuesta vacía." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> ActionsFeature(List<PostAction> postActions, int userId)
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
                    $"api/Feature/PostActions?userId={userId}", postActions, options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult> { Processed = false, Message = "El servidor devolvió una respuesta vacía." };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult> { Processed = false, Message = string.Concat("Ocurrió un error inesperado: ", ex.Message) };
            }
            return result;
        }

        public async Task<ApiResponse<List<byte>>> ExportFeatures(
            int userId, int supplierId, int? dealerId,
            string filter = "", bool? active = null)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Feature/Export?userId={userId}&supplierId={supplierId}";
                if (dealerId.HasValue)             url += $"&dealerId={dealerId.Value}";
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
