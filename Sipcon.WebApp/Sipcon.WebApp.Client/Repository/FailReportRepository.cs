namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;



    public class FailReportRepository(HttpClient http) : IFailReportService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<FailReport>>> GetFailReports(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<FailReport>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<FailReport>>>($"api/Service/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.FailReport}&dealerId={IdDealer}");


                result = result is null ? new ApiResponse<List<FailReport>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<FailReport>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<FailReport>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FailReport>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<FailReportType>>> GetFailReportTypes(int IdUser)
        {
            ApiResponse<List<FailReportType>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<FailReportType>>>($"api/Service/GetReportType");


                result = result is null ? new ApiResponse<List<FailReportType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",


                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<FailReportType>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<FailReportType>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FailReportType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<FailReport>> GetFailReport(int IdUser, int IdDealer, int IdFailReport) 
        {
            ApiResponse<FailReport>? result;
            try
            {
                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<FailReport>>>($"api/Service/GetOne?userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.FailReport}&dealerId={IdDealer}&serviceId={IdFailReport}");

                result = (resultlist is null) ? new ApiResponse<FailReport>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<FailReport>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.FirstOrDefault() ?? new FailReport()

                };

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<FailReport>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<FailReport>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<FailReport>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> CreateFailReport(FailReport FailReport, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {

                var _assistence = new FailReportUp()
                {
                    Id = FailReport.Id,
                    IsActive = FailReport.IsActive,
                    ReportTypeId = FailReport.ReportTypeId ?? 0,
                    OrderNumber = FailReport.OrderNumber ?? 0,
                    ServiceDate = FailReport.ServiceDate ?? DateTime.Now,
                    CustomerReport = FailReport.CustomerReport,
                    DealerReport = FailReport.DealerReport,
                    TechnicalSolution = FailReport.TechnicalSolution,
                    Paralyzed = FailReport.Paralyzed,
                    LicenseId = FailReport.LicenseId ?? 0,
                    DealerId = FailReport.DealerId ?? 0,
                    VehicleId = FailReport.VehicleId ?? 0,
                    Km = FailReport.KM ?? 0,
                    CustomerId = FailReport.CustomerId ?? 0,
                    InvoiceNumber = FailReport.InvoiceNumber,
                    InvoiceDate = FailReport.InvoiceDate ?? DateTime.Now,

                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostFailReport?userId={IdUser}", _assistence);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el FailReport: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }
                    
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

        public async Task<ApiResponse<List<ActionResult>>> UpdateFailReport(FailReport FailReport, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;

            try
            {
                var _assistence = new FailReportUp()
                {

                    Id = FailReport.Id,
                    IsActive = FailReport.IsActive,
                    ReportTypeId = FailReport.ReportTypeId ?? 0,
                    OrderNumber = FailReport.OrderNumber ?? 0,
                    ServiceDate = FailReport.ServiceDate ?? DateTime.Now,
                    CustomerReport = FailReport.CustomerReport,
                    DealerReport = FailReport.DealerReport,
                    TechnicalSolution = FailReport.TechnicalSolution,
                    Paralyzed = FailReport.Paralyzed,
                    LicenseId = FailReport.LicenseId ?? 0,
                    DealerId = FailReport.DealerId ?? 0,
                    VehicleId = FailReport.VehicleId ?? 0,
                    Km = FailReport.KM ?? 0,
                    CustomerId = FailReport.CustomerId ?? 0,
                    InvoiceNumber = FailReport.InvoiceNumber,
                    InvoiceDate = FailReport.InvoiceDate ?? DateTime.Now,

                };


                var response = await _http.PostAsJsonAsync($"api/Service/PostFailReport?userId={IdUser}", _assistence);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el FailReport: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<ActionResult>>> ActionsFailReport(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PostAction> PostActionList = ([]);
            try
            {


                var response = await _http.PostAsJsonAsync($"api/Service/PostActions?userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.FailReport}", PostActions);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el FailReport: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<byte>>> ExportFailReports(int IdUser, int IdDealer, string Filter = "")
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;
          
            try
            {
                
                var response = await _http.GetAsync($"api/Service/Export?filter={Filter}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.FailReport}&dealerId={IdDealer}");


                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el FailReport: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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


        /// <summary>
        /// DETALLES DE REPORTE FALLA
        ///  part = P , labortime = L
        /// </summary>

        public async Task<ApiResponse<List<FailReportDetail>>> GetFailReportDetails(int IdService, string Filter = "", ServiceDetailTypeEnum dType = ServiceDetailTypeEnum.LaborTime)
        {
            ApiResponse<List<FailReportDetail>>? result;

            try
            {
                var url = $"api/Service/GetDetails?serviceId={IdService}";

                url = (dType == ServiceDetailTypeEnum.LaborTime) ? $"{url}&type=L" : $"{url}&type=P";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<FailReportDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<FailReportDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<FailReportDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<FailReportDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<FailReportDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateFailReportDetail(FailReportDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<FailReportDetailUp> _ServiceList = ([]);
            try
            {
                var _Service = new FailReportDetailUp()
                {
                    Id          = Detail.Id,
                    ServiceId   = Detail.ServiceId,
                    ItemId      = Detail.ItemId,
                    Type        = Detail.Type,
                    Quantity    = Detail.Quantity ?? 0,
                    UnitPrice   = Detail.UnitPrice ?? 0,
                    IsExternal  = Detail.IsExternal,
                    IsTax       = Detail.IsTax,
                    IsActive    = Detail.IsActive 

                };

                _ServiceList.Add(_Service);

                var url = $"api/Service/PostDetails?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _ServiceList);

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

        public async Task<ApiResponse<List<ActionResult>>> UpdateFailReportDetail(FailReportDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {
                var _Detail = new FailReportDetailUp()
                {
                    Id = Detail.Id,
                    ServiceId = Detail.ServiceId,
                    ItemId = Detail.ItemId,
                    Type = Detail.Type,
                    Quantity = Detail.Quantity ?? 0,
                    UnitPrice = Detail.UnitPrice ?? 0,
                    IsExternal = Detail.IsExternal,
                    IsTax = Detail.IsTax,
                    IsActive = Detail.IsActive
                };

                var url = $"api/Service/PostDetails?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _Detail);

               
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

        public async Task<ApiResponse<List<ActionResult>>> ActionsFailReportDetail(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
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

                var url = $"api/Service/PostActionsDetails?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, PostActions, options);
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

        public async Task<ApiResponse<List<ActionResult>>> DeleteFailReportDetail(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
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

                var url = $"api/Service/Delete_Details?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, PostActions, options);
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


    }

}
