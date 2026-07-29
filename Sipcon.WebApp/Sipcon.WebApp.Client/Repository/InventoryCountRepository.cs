namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Microsoft.Extensions.Options;


    public class InventoryCountRepository(HttpClient http) : IInventoryCountService
    {
        private readonly HttpClient _http = http;

        
        public async Task<ApiResponse<List<InventoryCount>>> GetInventoryCount(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "",  string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<InventoryCount>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCount?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;


                result = await _http.GetFromJsonAsync<ApiResponse<List<InventoryCount>>>(url);
                

                result = (result is null) ? new ApiResponse<List<InventoryCount>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InventoryCount>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<InventoryCount>>> GetOneInventoryCount(int IdSupplier, int IdUser, int InventoryCountId)
        {
            ApiResponse<List<InventoryCount>>? result;

            try
            {
                var url = $"api/InventoryCount/GetOneInventoryCount?supplierId={IdSupplier}&userId={IdUser}&inventoryCountId={InventoryCountId}";
                result = await _http.GetFromJsonAsync<ApiResponse<List<InventoryCount>>>(url);


                result = (result is null) ? new ApiResponse<List<InventoryCount>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InventoryCount>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<byte>>> ExportInventoryCount(int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/InventoryCount" +
                    $"/ExportInventoryCount?supplierId={IdSupplier}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.Maintenance}";
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



        public async Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetails(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<GetInventoryCountDetail>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountDetail?supplierId={IdSupplier}&userId={IdUser}&inventoryId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;


                result = await _http.GetFromJsonAsync<ApiResponse<List<GetInventoryCountDetail>>>(url);


                result = (result is null) ? new ApiResponse<List<GetInventoryCountDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<GetInventoryCountDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }



    }

}
