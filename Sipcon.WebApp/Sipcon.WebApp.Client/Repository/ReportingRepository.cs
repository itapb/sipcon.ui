namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;
    using System.Dynamic;
    using System.Text.Json;

    public class ReportingRepository(HttpClient http) : IReportingService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<ReportingType>>> GetReportingType(int IdUser, int RowFrom = 0)
        {
            ApiResponse<List<ReportingType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<ReportingType>>>($"api/Reporting/GetReportingType?userId={IdUser}&rowFrom={RowFrom}");

                result = (resultlist is null) ? new ApiResponse<List<ReportingType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<List<ReportingType>>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.ToList() ?? new List<ReportingType>()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ReportingType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }


        public async Task<ApiResponse<List<ExpandoObject>>> GetReports(int IdReporting, int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? IdDealer = null)
        {
            ApiResponse<List<ExpandoObject>>? result;

            try
            {
                var url = $"api/Reporting/GetReports?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}&reportingId={IdReporting}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<ExpandoObject>>>(url);

                //var response = await _http.GetAsync(url);
                //var jsonString = await response.Content.ReadAsStringAsync();
                //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                //var items = JsonSerializer.Deserialize<List<ExpandoObject>>(jsonString, options);

                result = result is null ? new ApiResponse<List<ExpandoObject>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ExpandoObject>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

       
        public async Task<ApiResponse<List<byte>>> Export(int IdReporting, int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? IdDealer = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                var url = $"api/Reporting/Export?supplierId={IdSupplier}&userId={IdUser}&reportingId={IdReporting}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";

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
