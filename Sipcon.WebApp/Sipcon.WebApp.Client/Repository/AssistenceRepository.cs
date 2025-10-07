namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;



    public class AssistenceRepository(HttpClient http) : IAssistenceService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Assistence>>> GetAssistences(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Assistence>>? result;
            try
            {
                var url = $"api/Service/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}&serviceTypeId={(int)ServiceTypeEnum.Assistence}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Assistence>>>(url);

                result = result is null ? new ApiResponse<List<Assistence>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Assistence>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<Assistence>> GetAssistence(int IdUser, int IdDealer, int IdAssistence) 
        {
            ApiResponse<Assistence>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<Assistence>>>($"api/Service/GetOne?userId={IdUser}&serviceTypeId=2&dealerId={IdDealer}&serviceId={IdAssistence}");

                result = (resultlist is null) ? new ApiResponse<Assistence>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<Assistence>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.FirstOrDefault() ?? new Assistence()

                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Assistence>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<PossibleFault>>> GetPossibleFault(int IdUser)
        {
            ApiResponse<List<PossibleFault>>? result;

            try
            {
                var url = $"api/Service/GetPossibleFault";

                result = await _http.GetFromJsonAsync<ApiResponse<List<PossibleFault>>>(url);

                result = (result is null) ? new ApiResponse<List<PossibleFault>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PossibleFault>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<AssistanceType>>> GetAssistanceType(int IdUser)
        {
            ApiResponse<List<AssistanceType>>? result;

            try
            {
                var url = $"api/Service/GetAssistanceType";

                result = await _http.GetFromJsonAsync<ApiResponse<List<AssistanceType>>>(url);

                result = (result is null) ? new ApiResponse<List<AssistanceType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AssistanceType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<UserAssign>>> GetUserAssign(int IdSupplier, int IdUser, int RowFrom, string Filter = "", int? Id = null)
        {
            ApiResponse<List<UserAssign>>? result;

            try
            {
                var url = $"api/Service/GetUserAssign?supplierId={IdSupplier}&userId={IdUser}&irowFrom={RowFrom}";
                url = (Id.HasValue) ? $"{url}&Id={Id}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";


                result = await _http.GetFromJsonAsync<ApiResponse<List<UserAssign>>>(url);

                result = (result is null) ? new ApiResponse<List<UserAssign>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<UserAssign>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }



        public async Task<ApiResponse<ActionResult>> CreateAssistence(Assistence Assistence, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var _assistence = new AssistenceUp()
                {
                    Id = Assistence.Id,
                    IsActive = Assistence.IsActive,
                    OrderNumber = Assistence.OrderNumber ?? string.Empty,
                    ServiceDate = Assistence.ServiceDate ?? DateTime.Now,
                    CustomerReport = Assistence.CustomerReport,
                    DealerReport = Assistence.DealerReport,
                    Km = Assistence.Km ?? 0,
                    Paralyzed = Assistence.Paralyzed ?? false,
                    DealerId = Assistence.DealerId ?? 0,
                    VehicleId = Assistence.VehicleId ?? 0,
                    PossibleFaultId = Assistence.PossibleFaultId ?? 0
                };

                var response = await _http.PostAsJsonAsync($"api/Service/PostAssistence?userId={IdUser}", _assistence);

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

        public async Task<ApiResponse<ActionResult>> UpdateAssistence(Assistence Assistence, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var _assistence = new AssistenceUp()
                {
                    Id = Assistence.Id,
                    IsActive = Assistence.IsActive,
                    OrderNumber = Assistence.OrderNumber ?? string.Empty,
                    ServiceDate = Assistence.ServiceDate ?? DateTime.Now,
                    CustomerReport = Assistence.CustomerReport,
                    DealerReport = Assistence.DealerReport,
                    Km = Assistence.Km ?? 0,
                    Paralyzed = Assistence.Paralyzed ?? false,
                    DealerId = Assistence.DealerId ?? 0,
                    VehicleId = Assistence.VehicleId ?? 0,
                    CustomerId = Assistence.CustomerId ?? 0,
                    PossibleFaultId = Assistence.PossibleFaultId ?? 0

                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostAssistence?userId={IdUser}", _assistence);

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

        public async Task<ApiResponse<ActionResult>> ActionsAssistence(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Service/PostActions?userId={IdUser}&serviceTypeId=2", PostActions);

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

        public async Task<ApiResponse<List<byte>>> ExportAssistences(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Service/Export?supplierId={IdSupplier}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.Assistence}";
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

    }

}
