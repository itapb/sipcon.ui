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

        
        public async Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Vehicle>>? result;

            try
            {
                var url = $"api/Vehicle/GetAll?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = (IdDealer.HasValue && IdDealer.Value > 0) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                
                result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>(url);
                

                result = (result is null) ? new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

                if (IdDealer.HasValue && IdDealer.Value > 0)
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetAllAvailables?userId={IdUser}&dealerId={IdDealer}&rowFrom={RowFrom}&filter={Filter}");
                }
                else
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetAllAvailables?userId={IdUser}&rowFrom={RowFrom}&filter={Filter}");
                }



                result = (result is null) ? new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Vehicle>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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

        public async Task<ApiResponse<Vehicle>> GetVehicleBy(string Search, int IdUser,  SearchByEnum SearchBy, int? IdDealer)
        {
            ApiResponse<Vehicle>? result;
            try
            {

                var url = $"api/Vehicle/GetOneBy?userId={IdUser}&filterBy={(int)SearchBy}";
                url = (IdDealer.HasValue && IdDealer.Value > 0) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Search) ? url : $"{url}&filter={Search}";

                result = await _http.GetFromJsonAsync<ApiResponse<Vehicle>>(url);

                result = (result is null) ? new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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

        public async Task<ApiResponse<VehicleService>> GetVehicleFullBy(int IdUser, string Search,SearchByEnum SearchBy)
        {
            ApiResponse<VehicleService>? result;
            try
            {
                var url = $"api/Vehicle/GetVehicleFullBy?userId={IdUser}&filterBy={(int)SearchBy}";
                url = string.IsNullOrEmpty(Search) ? url : $"{url}&filter={Search}";

                result = await _http.GetFromJsonAsync<ApiResponse<VehicleService>>(url);

                result = (result is null) ? new ApiResponse<VehicleService>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<VehicleService>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<VehicleService>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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
                if (IdDealer.HasValue && IdDealer.Value > 0)
                {
                    Listresult = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetOneAvailable?userId={IdUser}&dealerId={IdDealer}&VinOrPlate={Search}");
                }
                else
                {
                    Listresult = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetOneAvailable?userId={IdUser}&VinOrPlate={Search}");
                }


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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<Vehicle>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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

        public async Task<ApiResponse<ActionResult>> CreateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<Vehicle> vehicles = ([]);
            try
            {
                
                vehicles.Add(Vehicle);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles);

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error Post Vehicle: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error Post Vehicle: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };
                
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

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception($"Error Post Vehicle: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                //}

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<List<byte>>> ExportVehicles(int IdSupplier, int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result; 
            string fileUrl = string.Empty;
            try
            {
                var url = $"api/Vehicle/Export?supplierId={IdSupplier}&userId={IdUser}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";


                var response = await _http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = false,
                        Message = "Error Exportación",
                        Data = []
                    };
                }
                else
                {
                    var fileContent = await response.Content.ReadAsByteArrayAsync();
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = true,
                        Message = "Exportación exitosa.",
                        Data = fileContent.ToList()
                    };
                }

                
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

        public async Task<ApiResponse<bool>> ImportVehicles(int IdSupplier, int IdUser, MultipartFormDataContent FormData )
        {
            ApiResponse<bool> result;
            
            try
            {
                var url = $"api/Vehicle/Import?supplierId={IdSupplier}&userId={IdUser}";

                var response = await _http.PostAsync(url, FormData);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = false,
                        Message = "Error Importar",
                        Data = false
                    };

                }
                else
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = true,
                        Message = "Importacion exitosa.",
                        Data = true
                    };
                }

                   
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = false
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = false
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = false
                };
            }

            return result;
        }

    }

}
