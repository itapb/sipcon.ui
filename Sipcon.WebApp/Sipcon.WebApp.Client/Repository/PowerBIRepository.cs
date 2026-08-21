namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;

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

        public async Task<ApiResponse<bool>> ReloadReport(string datasetId, string token)
        {
            try
            {
                var url = $"https://api.powerbi.com/v1.0/myorg/datasets/{datasetId}/refreshes";
                using var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse<bool>
                    {
                        Processed = true,
                        Data = true,
                        Message = "La actualización del conjunto de datos se inició exitosamente."
                    };
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.BadRequest && !string.IsNullOrEmpty(responseContent))
                {
                    using var doc = JsonDocument.Parse(responseContent);
                    if (doc.RootElement.TryGetProperty("error", out var errorElement) &&
                        errorElement.TryGetProperty("code", out var codeElement))
                    {
                        var errorCode = codeElement.GetString();

                        if (errorCode == "RefreshInProgressException")
                        {
                            return new ApiResponse<bool>
                            {
                                Processed = true, 
                                Data = false,    
                                Message = "El conjunto de datos ya se encuentra en proceso de actualización."
                            };
                        }
                    }
                }

                return new ApiResponse<bool>
                {
                    Processed = false,
                    Data = false,
                    Message = $"Error en la solicitud de Power BI ({response.StatusCode}): {responseContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Processed = false,
                    Data = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
        }
    }
}
