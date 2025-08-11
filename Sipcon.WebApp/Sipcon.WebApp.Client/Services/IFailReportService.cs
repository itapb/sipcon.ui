namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IFailReportService
    {

        public Task<ApiResponse<List<FailReport>>> GetFailReports(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<List<FailReportType>>> GetFailReportTypes(int IdUser);
        public Task<ApiResponse<FailReport>> GetFailReport(int IdUser, int IdDealer, int IdFailReport);
        public Task<ApiResponse<List<ActionResult>>> CreateFailReport(FailReport FailReport, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateFailReport(FailReport FailReport, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsFailReport(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportFailReports(int IdUser, int IdDealer, string Filter = "");


        public Task<ApiResponse<List<FailReportDetail>>> GetFailReportDetails(int IdService, string Filter = "", ServiceDetailTypeEnum dType = ServiceDetailTypeEnum.LaborTime);
        public Task<ApiResponse<List<ActionResult>>> CreateFailReportDetail(FailReportDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateFailReportDetail(FailReportDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsFailReportDetail(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> DeleteFailReportDetail(List<PostAction> PostActions, int IdUser);

    }
}
