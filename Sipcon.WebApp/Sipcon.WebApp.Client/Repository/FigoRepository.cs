namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class FigoRepository(HttpClient http) : IFigoService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<byte>>> ExportRelacionCxCPDF(string _activeCurrency, string _searchString)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Figo/ExportReportCxCPdf?Currency=" + _activeCurrency;
                if (!string.IsNullOrEmpty(_searchString)) url += $"&Filter={_searchString}";

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

        public async Task<ApiResponse<List<ReportConfig>>> GetFilterReport(int userId, int reportId, int? RowFrom = 0)
        {
            ApiResponse<List<ReportConfig>>? result;
            try
            {
                var url = $"/api/Figo/ReportsFilters?userId={userId}&reportId={reportId}&rowFrom={RowFrom}";


                result = await _http.GetFromJsonAsync<ApiResponse<List<ReportConfig>>>(url);

                result = result is null ? new ApiResponse<List<ReportConfig>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ReportConfig>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }


        public async Task<ApiResponse<List<Dictionary<string, object>>>> GetReportsFigo(int userId,int reportId,string jsonParameters)
        {
            // Cambiamos el tipo de la respuesta a Dictionary
            ApiResponse<List<Dictionary<string, object>>>? result;

            try
            {
                var url = $"/api/Figo/GetReportsContent?userId={userId}&reportId={reportId}&jsonParameters={jsonParameters}";

                // La magia ocurre aquí: Dictionary es nativo para el JSON de .NET
                result = await _http.GetFromJsonAsync<ApiResponse<List<Dictionary<string, object>>>>(url);

                if (result is null)
                {
                    result = new ApiResponse<List<Dictionary<string, object>>>()
                    {
                        Processed = false,
                        Message = "La respuesta del servidor no contiene datos.",
                    };
                }
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Dictionary<string, object>>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }



        public async Task<ApiResponse<List<byte>>> Export(int userId, int reportId, string jsonParameters)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/Figo/Export?userId={userId}&reportId={reportId}&jsonParameters={jsonParameters}";

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