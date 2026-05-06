namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Helper;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;

    public class RateRepository : IRateService
    {
        private readonly HttpClient _http;
        private readonly UserSession _session;

        public RateRepository(HttpClient http, UserSession session)
        {
            _http = http;
            _session = session;
        }

        public async Task<ApiResponse<List<Rate>>> GetRates(int? rowFrom = null, string? filter = null)
        {
            ApiResponse<List<Rate>>? result;
            try
            {
                var url = $"api/Rate/GetAll";
                if (rowFrom.HasValue)
                    url += $"?rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter))
                    url += $"{(rowFrom.HasValue ? "&" : "?")}filter={filter}";

                var response = await _http.GetFromJsonAsync<ApiResponse<List<Rate>>>(url);

                result = response ?? new ApiResponse<List<Rate>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Rate>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> SaveRate(Rate rate)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var url = $"api/Rate/Post?userId={_session.UserId}";
                var response = await _http.PostAsJsonAsync(url, rate);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
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

        public async Task<ApiResponse<List<byte>>> ExportRates()
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Rate/Export";
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
    }
}