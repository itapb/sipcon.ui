namespace Sipcon.WebApp.Client.Repository
{

    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class ReportDMSRepository(HttpClient http) : IReportDMSService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<ReportingType>>> GetImportType(int Idsupplier)
        {
            ApiResponse <List<ReportingType>>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<ReportingType>>>($"api/Service/GetImportType?supplierId={Idsupplier}");

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

        public async Task<ApiResponse<List<ReportDMS>>> GetReportDMS(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<ReportDMS>>? result;

            try
            {
                var url = $"api/Service/GetDMS?userId={IdUser}&supplierId={Idsupplier}&row={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<ReportDMS>>>(url);

                result = (result is null) ? new ApiResponse<List<ReportDMS>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ReportDMS>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<ActionResult>> ActionsReportDMS(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Service/PostActionsDMS?userId={IdUser}", PostActions);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

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

        public async Task<ApiResponse<ActionResult>> ImportReportDMS(int IdUser, int Idsupplier, int IdType, MultipartFormDataContent FormData)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var url = $"api/Service/ImportDMS?userId={IdUser}&supplierId={Idsupplier}&type={IdType}";
                var response = await _http.PostAsync(url, FormData);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

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

        public async Task<ApiResponse<List<byte>>> ExportReportDMS(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/Service/GetExportDms?userId={IdUser}&supplierId={Idsupplier}&row={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;

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
