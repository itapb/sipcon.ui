namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class InspectionRepository(HttpClient http) : IInspectionService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<Inspection>>> GetAllInspections(int supplierId, int rowFrom = 0, string filter = "")
        {
            ApiResponse<List<Inspection>>? result;
            try
            {
                var url = $"api/Inspections/TableGetAll?supplierId={supplierId}&rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Inspection>>>(url);
                result ??= new ApiResponse<List<Inspection>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Inspection>>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<InspectionFase>>> GetInspectionFase(int inspectionId)
        {
            ApiResponse<List<InspectionFase>>? result;
            try
            {
                var url = $"api/InspectionFase/GetAll?inspectionId={inspectionId}";
        
                result = await _http.GetFromJsonAsync<ApiResponse<List<InspectionFase>>>(url);
                result ??= new ApiResponse<List<InspectionFase>>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InspectionFase>>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<InspectionDetail>> GetInspectionDetails(int inspectionId)
        {
            ApiResponse<InspectionDetail>? result;
            try
            {
                var url = $"api/Inspections/GetOne?InspectionId={inspectionId}";

                result = await _http.GetFromJsonAsync<ApiResponse<InspectionDetail>>(url);
                result ??= new ApiResponse<InspectionDetail>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<InspectionDetail>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<InspectionFeatures>>> GetInspectionFeatures(int inspectionId, int faseId)
        {
            ApiResponse<List<InspectionFeatures>>? result;
            try
            {
                var url = $"api/InspectionsDetails/GetAll?InspectionId={inspectionId}&FaseId={faseId}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<InspectionFeatures>>>(url);
                result ??= new ApiResponse<List<InspectionFeatures>>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InspectionFeatures>>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<InspectionFiles>>> GetInpectionFiles(int recordId, String moduleName)
        {
            ApiResponse<List<InspectionFiles>>? result;
            try
            {
                var url = $"api/Attachment/GetAll?recordId={recordId}&moduleName={moduleName}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<InspectionFiles>>>(url);
                result ??= new ApiResponse<List<InspectionFiles>>
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InspectionFiles>>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<byte>>> GeneratePDF(int inspectionId)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var response = await _http.GetAsync($"api/Inspection/ExportPdf?InspectionId={inspectionId}");
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
