namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;


    public class VehicleColorRepository(HttpClient http) : IVehicleColorService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<VehicleColor>>> GetVehicleColors(int IdUser)
        {
            ApiResponse<List<VehicleColor>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<VehicleColor>>>($"api/Color/GetAll");

                result = (result is null) ? new ApiResponse<List<VehicleColor>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<VehicleColor>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }
        public async Task<VehicleColor> GetVehicleColor(int IdVehicleColor, int IdUser) 
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<bool> CreateVehicleColor(VehicleColor VehicleColor, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateVehicleColor(VehicleColor VehicleColor, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();

        }
      
    }

}
