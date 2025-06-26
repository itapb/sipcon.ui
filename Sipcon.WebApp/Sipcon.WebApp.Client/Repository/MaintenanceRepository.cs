namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;



    public class MaintenanceRepository(HttpClient http) : IMaintenanceService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Maintenance>>> GetMaintenances(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Maintenance>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<Maintenance>>>($"api/Service/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}&serviceTypeId=1&dealerId={IdDealer}");


                result = result is null ? new ApiResponse<List<Maintenance>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Maintenance>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Maintenance>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Maintenance>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Maintenance>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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

        public async Task<ApiResponse<List<ActionResult>>> CreateMaintenance(Maintenance Maintenance, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {

                var _maintenance = new MaintenanceUp()
                {
                    Id = Maintenance.Id,
                    IsActive = Maintenance.IsActive,
                    OrderNumber = Maintenance.OrderNumber ?? 0,
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

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Maintenance: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> UpdateMaintenance(Maintenance Maintenance, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;

            try
            {
                var _maintenance = new MaintenanceUp()
                {

                    Id = Maintenance.Id,
                    IsActive = Maintenance.IsActive,
                    OrderNumber = Maintenance.OrderNumber ?? 0,
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

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Maintenance: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> ActionsMaintenance(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PostAction> PostActionList = ([]);
            try
            {


                var response = await _http.PostAsJsonAsync($"api/Service/PostActions?userId={IdUser}&serviceTypeId=1", PostActions);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error accion Tipo Poliza: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;

        }

        public async Task<ApiResponse<List<byte>>> ExportMaintenances(int IdUser, int IdDealer, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                
                var response = await _http.GetAsync($"api/Service/Export?filter={Filter}&userId={IdUser}&serviceTypeId=1&dealerId={IdDealer}");
                    
                    
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Poliza: {response.StatusCode} - {response.ReasonPhrase}");
                }

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "Exportación exitosa.",
                    Data = fileContent.ToList()
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = []
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = []
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

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Poliza: {response.StatusCode} - {response.ReasonPhrase}");
                }

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "Exportación exitosa.",
                    Data = fileContent.ToList()
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = []
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = []
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
