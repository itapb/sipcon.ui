namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class FigoRepository(HttpClient http) : IFigoService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<FIGO_Reporte_RelacionCxC>>> GetRelacionCxC(string _activeCurrency, string _searchString)
        {
            ApiResponse<List<FIGO_Reporte_RelacionCxC>>? result;
            try
            {
                var url = $"api/Figo/ReportCxC?Currency=" +_activeCurrency;
                if (!string.IsNullOrEmpty(_searchString)) url += $"&Filter={_searchString}";


                result = await _http.GetFromJsonAsync<ApiResponse<List<FIGO_Reporte_RelacionCxC>>>(url);
                result ??= new ApiResponse<List<FIGO_Reporte_RelacionCxC>>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FIGO_Reporte_RelacionCxC>>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<byte>>> ExportRelacionCxCExcel(string _activeCurrency, string _searchString)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Figo/ExportReportCxC?Currency=" + _activeCurrency;
                if (!string.IsNullOrEmpty(_searchString)) url += $"&Filter={_searchString}";

                var response = await _http.GetAsync(url);
                var fileContent = await response.Content.ReadAsByteArrayAsync();

                result = fileContent is null || fileContent.Length == 0
                    ? new ApiResponse<List<byte>> { Processed = false, Message = "Error al exportar data.", Data = [] }
                    : new ApiResponse<List<byte>> { Processed = true, Message = string.Empty, Data = fileContent.ToList() };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = []
                };
            }
            return result;
        }

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


    }
}