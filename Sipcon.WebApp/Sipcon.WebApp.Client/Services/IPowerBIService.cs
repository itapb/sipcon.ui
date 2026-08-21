namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IPowerBIService
    {
        Task<ApiResponse<List<PowerBI_Reports>>> GetReportsPowerBI(int userId);

        Task<ApiResponse<PowerBI_ReportPortal>> GetReportPortal(string reportId, string token);

        Task<ApiResponse<PowerBI_Token>> GetTokenPowerBI();

        Task<ApiResponse<bool>> ReloadReport(string datasetId, string token);
    }
}
