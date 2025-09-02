namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface ILaborTimeService
    {
        public Task<ApiResponse<List<LaborTime>>> GetLaborTimes(int Idsupplier, int RowFrom = 0, string Filter = "", int? Idmodel = null);
        public Task<ApiResponse<ActionResult>> CreateLaborTime(LaborTime LaborTime, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateLaborTime(LaborTime LaborTime, int IdUser);
        public Task<ApiResponse<ActionResult>> DeleteLaborTimes(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportLaborTimes(int Idmodel, int Idsupplier, string Filter = "");
        public Task<ApiResponse<bool>> ImportLaborTimes(int IdUser, int Idmodel, MultipartFormDataContent FormData);

    }
}
