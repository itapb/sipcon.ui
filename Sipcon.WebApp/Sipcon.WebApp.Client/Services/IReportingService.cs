namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    using System.Dynamic;

    public interface IReportingService
    {

        public Task<ApiResponse<List<ReportingType>>> GetReportingType(int IdUser, int RowFrom = 0);
        public Task<ApiResponse<List<Dictionary<string, object>>>> GetReports(int IdReporting, int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? IdDealer = null, int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> Export(int IdReporting, int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? IdDealer = null, int? EstatusId = null);
        public Task<ApiResponse<List<ReportingTypeFigo>>> GetReportingTypeFigo(int IdUser, int RowFrom = 0);

    }
}
