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

        
        public async Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null)
        {
            ApiResponse<List<Vehicle>>? result;

            try
            {

                if (IdDealer.HasValue && IdDealer.Value > 0)
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetAll?userId={IdUser}&dealerId={IdDealer}&rowFrom={RowFrom}&filter={Filter}");
                }
                else
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetAll?userId={IdUser}&rowFrom={RowFrom}&filter={Filter}");
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
                if (IdDealer.HasValue && IdDealer.Value > 0)
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<Vehicle>>($"api/Vehicle/GetOneBy?userId={IdUser}&dealerId={IdDealer}&filter={Search}&filterBy={(int)SearchBy}");
                }
                else
                {
                    result = await _http.GetFromJsonAsync<ApiResponse<Vehicle>>($"api/Vehicle/GetOneBy?userId={IdUser}&filter={Search}&filterBy={(int)SearchBy}");
                }
                

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

        public async Task<ApiResponse<List<ActionResult>>> CreateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<Vehicle> vehicles = ([]);
            try
            {
                
                vehicles.Add(Vehicle);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Vehiculo: {response.StatusCode} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<ActionResult>>> UpdateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<Vehicle> vehicles  = ([]);
            try
            {
                vehicles.Add(Vehicle);

                //var options = new JsonSerializerOptions
                //{
                //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                //    IgnoreReadOnlyProperties = true,
                //    WriteIndented = true
                //};



                //var json = JsonSerializer.Serialize(vehicles, options);


                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                //var request = new HttpRequestMessage(HttpMethod.Post, $"http://10.23.212.20/sipconapi/api/Vehicle/Post_Vehicles?userId={IdUser}")
                //{
                //    Content = content
                //};
                ////request.Headers.Add("Authorization", "Bearer <tu_token>");
                //request.Headers.Add("accept", "*/*");

                //_http.DefaultRequestHeaders
                //  .Accept
                //  .Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //var response = await _http.SendAsync(request);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al Modificar un Vehiculo: {response.StatusCode} - {response.ReasonPhrase}");
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
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
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

        public async Task<ApiResponse<List<ActionResult>>> ActionsVehicle(List<PostAction> PostActions, int IdUser)
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

                
                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostActions?userId={IdUser}", PostActions, options);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error accion Vehiculo: {response.StatusCode} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<List<byte>>> ExportVehicles(int IdUser, string Filter = "")
        {
            ApiResponse<List<byte>> result; 
            string fileUrl = string.Empty;
            try
            {
                var response = await _http.GetAsync($"api/Vehicle/Export?filter={Filter}&userId={IdUser}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Vehiculos: {response.StatusCode} - {response.ReasonPhrase}");
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

        public async Task<ApiResponse<bool>> ImportVehicles(int IdUser, MultipartFormDataContent FormData )
        {
            ApiResponse<bool> result;
            
            try
            {
                var response = await _http.PostAsync($"api/Vehicle/Import?userId={IdUser}", FormData);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Importar Vehiculos: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = new ApiResponse<bool>()
                {
                    Processed = true,
                    Message = "Importacion exitosa.",
                    Data = true
                };
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
