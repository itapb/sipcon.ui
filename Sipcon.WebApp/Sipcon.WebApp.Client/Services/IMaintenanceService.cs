namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IMaintenanceService
    {

        public Task<ApiResponse<List<Maintenance>>> GetMaintenances(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<Maintenance>> GetMaintenance(int IdUser, int IdDealer, int IdMaintenance);
        public Task<ApiResponse<ActionResult>> CreateMaintenance(Maintenance Maintenance, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateMaintenance(Maintenance Maintenance, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsMaintenance(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportMaintenances(int IdUser, int IdDealer, string Filter = "");
        public Task<ApiResponse<List<byte>>> ExportPdfMaintenance(int IdUser, int IdDealer, int IdMaintenance);
        


    }
}
