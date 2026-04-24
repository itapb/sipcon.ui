namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class FeatureOptionRepository(HttpClient http) : IFeatureOptionService
    {
        private readonly HttpClient _http = http;

        // IMPORTANTE: la interfaz define (int userId, int featureId)
        // el orden debe coincidir exactamente
        public async Task<ApiResponse<List<FeatureOption>>> GetFeatureOptions(int userId, int featureId)
        {
            ApiResponse<List<FeatureOption>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<FeatureOption>>>(
                    $"api/FeatureOption/GetAll?featureId={featureId}&userId={userId}");
                result ??= new ApiResponse<List<FeatureOption>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FeatureOption>>
                {
                    Processed = false,
                    Message   = "Ocurrió un error inesperado: " + ex.Message
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> SaveFeatureOptions(List<FeatureOption> options, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/FeatureOption/Post?userId={userId}", options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = "Ocurrió un error inesperado: " + ex.Message
                };
            }
            return result;
        }
    }
}
