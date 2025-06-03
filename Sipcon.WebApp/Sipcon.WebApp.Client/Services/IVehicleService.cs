namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IVehicleService
    {

        public Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdUser, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<Vehicle>> GetVehicle(int IdVehicle, int IdUser);
        public Task<ApiResponse<Vehicle>> GetVehicleByVIN(string VIN, int IdUser, int IdDealer);
        public Task<ApiResponse<List<ActionResult>>> CreateVehicle(Vehicle Vehicle, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateVehicle(Vehicle Vehicle, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsVehicle(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportVehicles(int IdUser, string Filter = "");
        public Task<ApiResponse<bool>> ImportVehicles(int IdUser, MultipartFormDataContent FormData);

    }
}
