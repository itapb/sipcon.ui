namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class FeatureValueTypeRepository(HttpClient http) : IFeatureValueTypeService
    {
        private readonly HttpClient _http = http;
        private List<FeatureValueType>? _cache = null;

        public async Task<ApiResponse<List<FeatureValueType>>> GetFeatureValueTypes(int userId)
        {
            if (_cache is not null)
                return new ApiResponse<List<FeatureValueType>> { Processed = true, Data = _cache };

            ApiResponse<List<FeatureValueType>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<FeatureValueType>>>(
                    $"api/FeatureValueType/GetAll?userId={userId}");
                result ??= new ApiResponse<List<FeatureValueType>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };

                if (result.Processed && result.Data is not null)
                    _cache = result.Data;
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FeatureValueType>>
                {
                    Processed = false,
                    Message   = "Ocurrió un error inesperado: " + ex.Message
                };
            }
            return result;
        }
    }
}
