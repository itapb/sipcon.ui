namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IVehicleService
    {

        public Task<ApiResponse<List<Vehicle>>> GetVehicles(int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null);
        public Task<ApiResponse<List<Vehicle>>> GetVehiclesAvailables(int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null);
        public Task<ApiResponse<Vehicle>> GetVehicle(int IdVehicle, int IdUser);
        public Task<ApiResponse<Vehicle>> GetVehicleBy(string Search, int IdUser, SearchByEnum SearchBy, int? IdDealer);
        public Task<ApiResponse<VehicleService>> GetVehicleFullBy(int IdUser, string Search, SearchByEnum SearchBy);
        public Task<ApiResponse<Vehicle>> GetVehicleAvailable(string Search, int IdUser, int? IdDealer = null);
        public Task<ApiResponse<List<ActionResult>>> CreateVehicle(Vehicle Vehicle, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateVehicle(Vehicle Vehicle, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsVehicle(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportVehicles(int IdUser, string Filter = "");
        public Task<ApiResponse<bool>> ImportVehicles(int IdUser, MultipartFormDataContent FormData);

    }
}
