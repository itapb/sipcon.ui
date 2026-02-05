namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IReportDMSService
    {
        public Task<ApiResponse<List<ReportingType>>> GetImportType(int Idsupplier);
        public Task<ApiResponse<List<ReportDMS>>> GetReportDMS(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "",string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<ActionResult>> ActionsReportDMS(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<ActionResult>> ImportReportDMS(int IdUser, int Idsupplier, int IdType, MultipartFormDataContent FormData);
        public Task<ApiResponse<List<byte>>> ExportReportDMS(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);

    }
}
