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

        
        public async Task<ApiResponse<List<GetInventoryCount>>> GetInventoryCount(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "",  string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<GetInventoryCount>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCount?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url; 


                result = await _http.GetFromJsonAsync<ApiResponse<List<GetInventoryCount>>>(url);
                

                result = (result is null) ? new ApiResponse<List<GetInventoryCount>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<GetInventoryCount>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<GetInventoryCount>>> GetOneInventoryCount(int IdSupplier, int IdUser, int InventoryCountId)
        {
            ApiResponse<List<GetInventoryCount>>? result;

            try
            {
                var url = $"api/InventoryCount/GetOneInventoryCount?supplierId={IdSupplier}&userId={IdUser}&inventoryCountId={InventoryCountId}";
                result = await _http.GetFromJsonAsync<ApiResponse<List<GetInventoryCount>>>(url);


                result = (result is null) ? new ApiResponse<List<GetInventoryCount>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<GetInventoryCount>>()
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
                var url = $"api/InventoryCount" + $"/ExportInventoryCount?supplierId={IdSupplier}&userId={IdUser}&serviceTypeId={(int)ServiceTypeEnum.Maintenance}";
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



        public async Task<ApiResponse<List<GetCountFull>>> GetInventoryCountDetailByZone(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null)
        {
            ApiResponse<List<GetCountFull>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountDetailByZone?supplierId={IdSupplier}&userId={IdUser}&inventoryId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;

                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
                result = await _http.GetFromJsonAsync<ApiResponse<List<GetCountFull>>>(url);

                result = (result is null) ? new ApiResponse<List<GetCountFull>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<GetCountFull>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }


            return result;
        }

        public async Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetail(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? ZoneId = null, bool? Assign = null, int? Diference = null)
        {
            ApiResponse<List<GetInventoryCountDetail>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountDetail?supplierId={IdSupplier}&userId={IdUser}&inventoryId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;
                url = (ZoneId.HasValue) ? $"{url}&idZone={ZoneId}" : url;
                url = (Assign.HasValue) ? $"{url}&Assign={Assign}" : url;
                url = (Diference.HasValue) ? $"{url}&Diference={Diference}" : url;  
                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
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


        public async Task<ApiResponse<List<InventoryCountType>>> GetInventoryCountTypes(int IdUser)
        {
            ApiResponse<List<InventoryCountType>>? result;

            try
            {
                var url = $"api/InventoryCount/GetCountType?userId={IdUser}";
                result = await _http.GetFromJsonAsync<ApiResponse<List<InventoryCountType>>>(url);


                result = (result is null) ? new ApiResponse<List<InventoryCountType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<InventoryCountType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }


        public async Task<ApiResponse<ActionResult>> UpdateInventoryCount(GetInventoryCount InventoryCount, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var _inventoryCount = new InventoryCount()
                {
                    Id = InventoryCount.Id,
                    Description = InventoryCount.Description,
                    TypeId = InventoryCount.TypeId,
                    SupplierId = InventoryCount.SupplierId
                };

                var response = await _http.PostAsJsonAsync($"api/InventoryCount/PostInventoryCount?userId={IdUser}", _inventoryCount);

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


        public async Task<ApiResponse<ActionResult>> UpdateInventoryCountDetail(List<GetInventoryCountDetail> InventoryCountDetails, int IdUser)
        {
            ApiResponse<ActionResult> result;

                    try
                    {
                        var count = InventoryCountDetails.Select(InventoryCount => new PostInventoryCountDetail
                            {
                                InventoryId = InventoryCount.InventoryId ?? 0,
                                InnerCode = InventoryCount.InnerCode ?? string.Empty,
                                Location = InventoryCount.Location ?? string.Empty,
                                Quantity = InventoryCount.QuantityNew ?? 0,
                                UserId = IdUser
                            }).ToList();

                        var response = await _http.PostAsJsonAsync($"api/InventoryCount/PostInventoryCountDetail?userId={IdUser}",
                            count
                        );

                        if (response.IsSuccessStatusCode)
                        {
                            result = await response.Content
                                .ReadFromJsonAsync<ApiResponse<ActionResult>>()
                                ?? new ApiResponse<ActionResult>
                                {
                                    Processed = false,
                                    Message = "El servidor devolvió una respuesta vacía."
                                };
                        }
                        else
                        {
                            var errorMessage = await response.Content.ReadAsStringAsync();

                            result = new ApiResponse<ActionResult>
                            {
                                Processed = false,
                                Message = string.IsNullOrWhiteSpace(errorMessage)
                                    ? $"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}"
                                    : errorMessage
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        result = new ApiResponse<ActionResult>
                        {
                            Processed = false,
                            Message = $"Ocurrió un error inesperado: {ex.Message}"
                        };
                    }

                    return result;
                }




        public async Task<ApiResponse<ActionResult>> ActionsInventoryCount(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var response = await _http.PostAsJsonAsync($"api/InventoryCount/PostInventoryCountActions?userId={IdUser}", PostActions);

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


        public async Task<ApiResponse<ActionResult>> ActionsInventoryCountDetail(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;

            try
            {
                var response = await _http.PostAsJsonAsync($"api/InventoryCount/ActionsInventoryCountDetail?userId={IdUser}", PostActions);

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


        public async Task<ApiResponse<List<byte>>> ExportPdfInventoryCount(int inventoryId, List<int> formIds, int supplierId, int userId)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                string formsQuery = formIds != null && formIds.Any()
                    ? string.Join("&", formIds.Select(id => $"formIds={id}"))
                    : string.Empty;

                var response = await _http.GetAsync($"api/Inventory/ExportPdfInventoryCount?inventoryId={inventoryId}&supplierId={supplierId}&userId={userId}&{formsQuery}");

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


        public async Task<ApiResponse<List<ZoneOption>>> GetZoneCount(int IdUser, int SupplierId)
        {
            try
            {
                // Cambia List<ZoneOption> por ApiResponse<List<ZoneOption>>
                var response = await _http.GetFromJsonAsync<ApiResponse<List<ZoneOption>>>(
                    $"api/InventoryCount/GetZoneCount?userId={IdUser}&supplierId={SupplierId}"
                );

                if (response is null)
                {
                    return new ApiResponse<List<ZoneOption>>
                    {
                        Processed = false,
                        Message = "La respuesta del servidor fue nula."
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ZoneOption>>
                {
                    Processed = false,
                    Message = $"Ocurrió un error inesperado: {ex.Message}"
                };
            }
        }


        public async Task<ApiResponse<List<CountSummary>>> GetCountSummary(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0)
        {
            ApiResponse<List<CountSummary>>? result;

            try
            {
                var url = $"api/InventoryCount/GetCountSummary?supplierId={IdSupplier}&userId={IdUser}&inventoryId={inventoryCountId}&rowFrom={RowFrom}";
                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
                result = await _http.GetFromJsonAsync<ApiResponse<List<CountSummary>>>(url);

                result = (result is null) ? new ApiResponse<List<CountSummary>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<CountSummary>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }


            return result;
        }

        public async Task<ApiResponse<List<CountTotal>>> GetInventoryCountTotal(int IdSupplier, int IdUser, int inventoryCountId, int? RowFrom = 0, string? Filter = "", int? Diference = null)
        {
            ApiResponse<List<CountTotal>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountTotal?supplierId={IdSupplier}&userId={IdUser}&inventoryCountId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = (Diference.HasValue) ? $"{url}&Diference={Diference}" : url;
                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
                result = await _http.GetFromJsonAsync<ApiResponse<List<CountTotal>>>(url);

                result = (result is null) ? new ApiResponse<List<CountTotal>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<CountTotal>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }


            return result;
        }



        public async Task<ApiResponse<List<byte>>> ExportInventoryCountTotal(int IdSupplier, int IdUser, int inventoryCountId, int? RowFrom = null, string Filter = "", int? Diference = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/InventoryCount/GetExportInventoryCountTotal?supplierId={IdSupplier}&userId={IdUser}&inventoryCountId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = (Diference.HasValue) ? $"{url}&Diference={Diference}" : url;
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


        public async Task<ApiResponse<List<byte>>> ExportInventoryCountDetail(int IdSupplier, int IdUser, int inventoryCountId, int? RowFrom = null, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? ZoneId = null, bool? Assign = null, int? Diference = null)
        {
            ApiResponse<List<byte>> result;
            string fileUrl = string.Empty;

            try
            {
                var url = $"api/InventoryCount/GetExportInventoryCountDetail?supplierId={IdSupplier}&userId={IdUser}&inventoryId={inventoryCountId}&rowFrom={RowFrom}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";
                url = (EstatusId.HasValue) ? $"{url}&estatusId={EstatusId}" : url;
                url = (ZoneId.HasValue) ? $"{url}&idZone={ZoneId}" : url;
                url = (Assign.HasValue) ? $"{url}&Assign={Assign}" : url;
                url = (Diference.HasValue) ? $"{url}&Diference={Diference}" : url;
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


        public async Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetailByForm(int inventoryId, int formId, int supplierId, int userId)
        {
            ApiResponse<List<GetInventoryCountDetail>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountDetailByForm?supplierId={supplierId}&userId={userId}&inventoryId={inventoryId}&formId={formId}";
               
                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
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


        public async Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetailAll(int inventoryId, int partId, int locationId, int supplierId, int userId)
        {
            ApiResponse<List<GetInventoryCountDetail>>? result;

            try
            {
                var url = $"api/InventoryCount/GetInventoryCountDetailAll?supplierId={supplierId}&userId={userId}&inventoryCountId={inventoryId}&partId={partId}&locationId={locationId}";

                // Se cambia GetInventoryCountDetail por GetCountFull para que coincida con el JSON anidado
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

        public async Task<ApiResponse<List<ImportStockCountResult>>> ImportStockCount( int IdSupplier, int IdUser, int InventoryCountId, MultipartFormDataContent formData)
          {
            ApiResponse<List<ImportStockCountResult>>? result;
            try
            {
               var url = $"api/StockCount/ImportStockCount?userId={IdUser}&supplierId={IdSupplier}&inventoryId={InventoryCountId}";
                var response = await _http.PostAsync(url, formData);
                if (response.IsSuccessStatusCode)
                {
                   result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ImportStockCountResult>>>();
               }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    result = new ApiResponse<List<ImportStockCountResult>>()
                    {
                        Processed = false,
                        Message = errorMessage
                    };
                }

               result = (result is null) ? new ApiResponse<List<ImportStockCountResult>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;
           }
           catch (Exception ex)
            {
                result = new ApiResponse<List<ImportStockCountResult>>()
                {
                   Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }


    }
}

                
