namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IVehicleColorService
    {

        public Task<ApiResponse<List<VehicleColor>>> GetVehicleColors(int IdUser);
        public Task<VehicleColor> GetVehicleColor(int IdVehicleColor, int IdUser);
        public Task<bool> CreateVehicleColor(VehicleColor VehicleColor, int IdUser);
        public Task<bool> UpdateVehicleColor(VehicleColor VehicleColor, int IdUser);


    }
}
