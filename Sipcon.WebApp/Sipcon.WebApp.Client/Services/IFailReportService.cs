namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IFailReportService
    {

        public Task<ApiResponse<List<FailReport>>> GetFailReports(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<FailReportType>>> GetFailReportTypes(int IdUser);
        public Task<ApiResponse<FailReport>> GetFailReport(int IdUser, int IdDealer, int IdFailReport);
        public Task<ApiResponse<ActionResult>> CreateFailReport(FailReport FailReport, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateFailReport(FailReport FailReport, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsFailReport(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsFailReportProcess(List<PostActionProcess> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportFailReports(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> ExportFailReportsClosed(int IdSupplier, int IdUser, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<FailReport>>> GetServiceFailClosed(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> ExportPdfSRG(int IdUser, int IdService, int? IdDealer = null);
        public Task<ApiResponse<List<byte>>> ExportReportSRG(int IdUser, int IdSupplier, int IdDealer);
        public Task<ApiResponse<List<FailReport>>> GetFailReportsToGenerate(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "");



        public Task<ApiResponse<List<FailReportDetail>>> GetFailReportDetails(int IdService, string Filter = "", ServiceDetailTypeEnum dType = ServiceDetailTypeEnum.LaborTime);
        public Task<ApiResponse<ActionResult>> CreateFailReportDetail(FailReportDetail Detail, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateFailReportDetail(FailReportDetail Detail, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsFailReportDetail(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<ActionResult>> DeleteFailReportDetail(List<PostAction> PostActions, int IdUser);

        public Task<ApiResponse<Part>> GetPartExternal(int IdUser, int IdPartExternal);
        public Task<ApiResponse<LaborTime>> GetLaborTimeExternal(int IdUser, int IdLaborTimeExternal);
        public Task<ApiResponse<ActionResult>> CreatePartExternal(PartExternal partExternal, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdatePartExternal(PartExternal partExternal, int IdUser);
        

    }
}
