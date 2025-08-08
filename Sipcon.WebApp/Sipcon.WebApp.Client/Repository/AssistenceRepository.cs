namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;



    public class AssistenceRepository(HttpClient http) : IAssistenceService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Assistence>>> GetAssistences(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Assistence>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<Assistence>>>($"api/Service/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.Assistence}&dealerId={IdDealer}");


                result = result is null ? new ApiResponse<List<Assistence>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Assistence>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Assistence>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Assistence>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Assistence>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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

        public async Task<ApiResponse<List<ActionResult>>> CreateAssistence(Assistence Assistence, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {

                var _assistence = new AssistenceUp()
                {
                    Id = Assistence.Id,
                    IsActive = Assistence.IsActive,
                    OrderNumber = Assistence.OrderNumber ?? 0,
                    ServiceDate = Assistence.ServiceDate ?? DateTime.Now,
                    CustomerReport = Assistence.CustomerReport,
                    DealerReport = Assistence.DealerReport,
                    TechnicalSolution = Assistence.TechnicalSolution,
                    Km = Assistence.Km ?? 0,
                    DealerId = Assistence.DealerId ?? 0,
                    VehicleId = Assistence.VehicleId ?? 0

                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostAssistence?userId={IdUser}", _assistence);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Assistence: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<ActionResult>>> UpdateAssistence(Assistence Assistence, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;

            try
            {
                var _assistence = new AssistenceUp()
                {

                    Id = Assistence.Id,
                    IsActive = Assistence.IsActive,
                    OrderNumber = Assistence.OrderNumber ?? 0,
                    ServiceDate = Assistence.ServiceDate ?? DateTime.Now,
                    CustomerReport = Assistence.CustomerReport,
                    DealerReport = Assistence.DealerReport,
                    TechnicalSolution = Assistence.TechnicalSolution,
                    Km = Assistence.Km ?? 0,
                    DealerId = Assistence.DealerId ?? 0,
                    VehicleId = Assistence.VehicleId ?? 0,
                    CustomerId = Assistence.CustomerId ?? 0,

                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostAssistence?userId={IdUser}", _assistence);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Assistence: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<ActionResult>>> ActionsAssistence(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PostAction> PostActionList = ([]);
            try
            {


                var response = await _http.PostAsJsonAsync($"api/Service/PostActions?userId={IdUser}&serviceTypeId=2", PostActions);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error accion Tipo Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<byte>>> ExportAssistences(int IdUser, int IdDealer, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                
                var response = await _http.GetAsync($"api/Service/Export?filter={Filter}&userId={IdUser}&serviceTypeId=2&dealerId={IdDealer}");
                    
                    
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Poliza: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
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
