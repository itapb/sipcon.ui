namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;

    public class PowerBIRepository(HttpClient http) : IPowerBIService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<PowerBI_Reports>>> GetReportsPowerBI(int userId)
        {
            ApiResponse<List<PowerBI_Reports>>? result;
            try
            {
                var url = $"api/PowerBI/GetReports?userId={userId}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<PowerBI_Reports>>>(url);
                result ??= new ApiResponse<List<PowerBI_Reports>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PowerBI_Reports>>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<PowerBI_Token>> GetTokenPowerBI()
        {
            ApiResponse<PowerBI_Token>? result;
            try
            {
                var url = $"api/PowerBI/GetToken";

                result = await _http.GetFromJsonAsync<ApiResponse<PowerBI_Token>>(url);
                result ??= new ApiResponse<PowerBI_Token>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<PowerBI_Token>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<PowerBI_ReportPortal>> GetReportPortal(string reportId, string token)
        {
            ApiResponse<PowerBI_ReportPortal> result;
            try
            {
                var url = $"https://api.powerbi.com/v1.0/myorg/reports/{reportId}";
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _http.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<PowerBI_ReportPortal>();

                result = data is null
                    ? new ApiResponse<PowerBI_ReportPortal>
                    {
                        Processed = false,
                        Message = "La respuesta del servidor no contiene datos."
                    }
                    : new ApiResponse<PowerBI_ReportPortal>
                    {
                        Processed = true,
                        Data = data
                    };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<PowerBI_ReportPortal>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }
    }
}
