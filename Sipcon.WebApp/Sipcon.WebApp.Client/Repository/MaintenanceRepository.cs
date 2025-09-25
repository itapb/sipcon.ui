namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;



    public class MaintenanceRepository(HttpClient http) : IMaintenanceService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Maintenance>>> GetMaintenances(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Maintenance>>? result;

            try
            {
                var url = $"api/Service/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}&serviceTypeId={(int)ServiceTypeEnum.Maintenance}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Maintenance>>>(url);
                
                result = result is null ? new ApiResponse<List<Maintenance>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Maintenance>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<Maintenance>> GetMaintenance(int IdUser, int IdDealer, int IdMaintenance) 
        {
            ApiResponse<Maintenance>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<Maintenance>>>($"api/Service/GetOne?userId={IdUser}&serviceTypeId=1&dealerId={IdDealer}&serviceId={IdMaintenance}");
                
                result = (resultlist is null) ? new ApiResponse<Maintenance>()
                 {
                     Processed = false,
                     Message = "La respuesta del servidor no contiene datos."

                 } : new ApiResponse<Maintenance>()
                 {
                     Processed = resultlist.Processed,
                     Total = resultlist.Total,
                     Message = resultlist.Message,
                     Data = resultlist.Data.FirstOrDefault() ?? new Maintenance()
                 };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Maintenance>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreateMaintenance(Maintenance Maintenance, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            try
            {

                var _maintenance = new MaintenanceUp()
                {
                    Id = Maintenance.Id,
                    IsActive = Maintenance.IsActive,
                    OrderNumber = Maintenance.OrderNumber ?? string.Empty,
                    ServiceDate = Maintenance.ServiceDate ?? DateTime.Now,
                    DealerReport = Maintenance.DealerReport,
                    PolicyDetailId = Maintenance.PolicyDetailId ?? 0,
                    Km = Maintenance.Km ?? 0,
                    DealerId = Maintenance.DealerId ?? 0,
                    VehicleId = Maintenance.VehicleId ?? 0,
                    CustomerId = Maintenance.CustomerId ?? 0,
                    InvoiceNumber = Maintenance.InvoiceNumber,
                    InvoiceDate = Maintenance.InvoiceDate ?? DateTime.Now
                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostMaintenance?userId={IdUser}", _maintenance);

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

        public async Task<ApiResponse<ActionResult>> UpdateMaintenance(Maintenance Maintenance, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var _maintenance = new MaintenanceUp()
                {
                    Id = Maintenance.Id,
                    IsActive = Maintenance.IsActive,
                    OrderNumber = Maintenance.OrderNumber ?? string.Empty,
                    ServiceDate = Maintenance.ServiceDate ?? DateTime.Now,
                    DealerReport = Maintenance.DealerReport ?? string.Empty,
                    PolicyDetailId = Maintenance.PolicyDetailId ?? 0,
                    Km = Maintenance.Km ?? 0,
                    DealerId = Maintenance.DealerId ?? 0,
                    VehicleId = Maintenance.VehicleId ?? 0,
                    CustomerId = Maintenance.CustomerId ?? 0,
                    InvoiceNumber = Maintenance.InvoiceNumber,
                    InvoiceDate = Maintenance.InvoiceDate ?? DateTime.Now
                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostMaintenance?userId={IdUser}", _maintenance);

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

        public async Task<ApiResponse<ActionResult>> ActionsMaintenance(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Service/PostActions?userId={IdUser}&serviceTypeId=1", PostActions);

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

        public async Task<ApiResponse<List<byte>>> ExportMaintenances(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                var url = $"api/Service/Export?supplierId={IdSupplier}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.Maintenance}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

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

        public async Task<ApiResponse<List<byte>>> ExportPdfMaintenance(int IdUser, int IdDealer, int IdMaintenance)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {

                var response = await _http.GetAsync($"api/Service/ExportPdf?userId={IdUser}&serviceTypeId=1&dealerId={IdDealer}&serviceId={IdMaintenance}");

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
