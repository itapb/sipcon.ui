namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Microsoft.Extensions.Options;


    public class VehicleRepository(HttpClient http) : IVehicleService
    {
        private readonly HttpClient _http = http;

        
        public async Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<Vehicle>>? result;

            try
            {
                var url = $"api/Vehicle/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;

                result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>(url);
                

                result = (result is null) ? new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<Vehicle>>> GetVehiclesAvailables(int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Vehicle>>? result;

            try
            {
                var url = $"api/Vehicle/GetAllAvailables?userId={IdUser}&rowFrom={RowFrom}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>(url);

                result = (result is null) ? new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<Vehicle>> GetVehicle(int IdVehicle, int IdUser) 
        {
            ApiResponse<Vehicle>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Vehicle>>($"api/Vehicle/GetOne?vehicleId={IdVehicle}&userId={IdUser}");

                result = (result is null) ? new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<Vehicle>> GetVehicleBy(string Search, int IdUser,  SearchByEnum SearchBy, int? IdDealer)
        {
            ApiResponse<Vehicle>? result;
            try
            {

                var url = $"api/Vehicle/GetOneBy?userId={IdUser}&filterBy={(int)SearchBy}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Search) ? url : $"{url}&filter={Search}";

                result = await _http.GetFromJsonAsync<ApiResponse<Vehicle>>(url);

                result = (result is null) ? new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<VehicleService>> GetVehicleFullBy(int IdSupplier, int IdUser, string Search,SearchByEnum SearchBy)
        {
            ApiResponse<VehicleService>? result;
            try
            {
                var url = $"api/Vehicle/GetVehicleFullBy?supplierId={IdSupplier}&userId={IdUser}&filterBy={(int)SearchBy}";
                url = string.IsNullOrEmpty(Search) ? url : $"{url}&filter={Search}";

                result = await _http.GetFromJsonAsync<ApiResponse<VehicleService>>(url);

                result = (result is null) ? new ApiResponse<VehicleService>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<VehicleService>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<Vehicle>> GetVehicleAvailable(string Search, int IdUser, int? IdDealer = null)
        {
            ApiResponse<Vehicle>? result;
            try
            {
                ApiResponse<List<Vehicle>>? Listresult;

                var url = $"api/Vehicle/GetOneAvailable?userId={IdUser}&VinOrPlate={Search}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                
                Listresult = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>(url);

                result = Listresult is not null ? new ApiResponse<Vehicle>()
                {
                    Processed = Listresult.Processed,
                    Message = Listresult.Message,
                    Data = Listresult.Data.FirstOrDefault() ?? new Vehicle()
                } : new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };


            }
            catch (Exception ex)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<VehicleRecord>> GetRecordVehicle(int IdSupplier, int IdUser, string Vin)
        {
            ApiResponse<VehicleRecord>? result;

            try
            {
                var url = $"api/Vehicle/GetRecordVehicle?supplierId={IdSupplier}&userId={IdUser}";
                url = string.IsNullOrEmpty(Vin) ? url : $"{url}&vin={Vin}";

                result = await _http.GetFromJsonAsync<ApiResponse<VehicleRecord>>(url);


                result = (result is null) ? new ApiResponse<VehicleRecord>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<VehicleRecord>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<ActionResult>> CreateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<Vehicle> vehicles = ([]);
            try
            {
                vehicles.Add(Vehicle);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles);

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

        public async Task<ApiResponse<ActionResult>> UpdateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<Vehicle> vehicles  = ([]);
            try
            {
                vehicles.Add(Vehicle);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles);

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

        public async Task<ApiResponse<ActionResult>> ActionsVehicle(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };
                
                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostActions?userId={IdUser}", PostActions, options);

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

        public async Task<ApiResponse<List<byte>>> ExportVehicles(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<byte>> result; 
            string fileUrl = string.Empty;
            try
            {
                var url = $"api/Vehicle/Export?supplierId={IdSupplier}&userId={IdUser}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = (IdDealer.HasValue) ? $"{url}&dealerId={IdDealer}" : url;
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

        public async Task<ApiResponse<ActionResult>> ImportVehicles(int IdSupplier, int IdUser, MultipartFormDataContent FormData )
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var url = $"api/Vehicle/Import?supplierId={IdSupplier}&userId={IdUser}";

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


        public async Task<ApiResponse<ActionResult>> ImportPlates(int IdSupplier, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var url = $"api/Vehicle/ImportPlate?supplierId={IdSupplier}&userId={IdUser}";

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

    }

}
