namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class VehicleRepository(HttpClient http) : IVehicleService
    {
        private readonly HttpClient _http = http;

        


        public async Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Vehicle>>? result;

            try
            {
            
                result = await _http.GetFromJsonAsync<ApiResponse<List<Vehicle>>>($"api/Vehicle/GetAll?filter={Filter}&rowFrom={RowFrom}&userId={IdUser}");

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

        public async Task<ApiResponse<List<ActionResult>>> CreateVehicle(Vehicle Vehicle, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<Vehicle> vehicles = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                vehicles.Add(Vehicle);

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles, options);

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
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                vehicles.Add(Vehicle);

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

                var response = await _http.PostAsJsonAsync($"api/Vehicle/PostVehicles?userId={IdUser}", vehicles, options);

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


    }

}
