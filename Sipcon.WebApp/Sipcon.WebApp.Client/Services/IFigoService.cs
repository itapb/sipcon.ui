using static System.Collections.Specialized.BitVector32;

namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFigoService
    {
        
        Task<ApiResponse<List<ReportConfig>>> GetFilterReport(int userId, int reportId, int? RowFrom = 0);
        Task<ApiResponse<List<Dictionary<string, object>>>> GetReportsFigo(int userId,int idSupplier,int rowFrom, int reportId, string jsonParameters, string? filter = null);
        public Task<ApiResponse<List<byte>>> Export(int userId,int supplierId, int reportId, string jsonParameters, string? filter = null);
        Task<ApiResponse<List<FilterOptionDto>>> GetFilterOptions(int userId, int reportId, int? RowFrom = null);
        Task<ApiResponse<List<byte>>> ExportPDF(int userId, int idSupplier, int rowFrom, int reportId, string jsonParameters, string? filter = null);
    }
}