namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IInspectionService
    {
        Task<ApiResponse<List<Inspection>>> GetAllInspections(int supplierId, int rowFrom = 0, string filter = "");
        Task<ApiResponse<List<InspectionFase>>> GetInspectionFase(int inspectionId);
        Task<ApiResponse<InspectionDetail>> GetInspectionDetails(int inspectionId);
        Task<ApiResponse<List<InspectionFeatures>>> GetInspectionFeatures(int inspectionId, int faseId);
        Task<ApiResponse<List<InspectionFiles>>> GetInpectionFiles(int recordId, String moduleName);
        Task<ApiResponse<List<byte>>> GeneratePDF(int inspectionId);

        // Export
        Task<ApiResponse<List<byte>>> ExportInspections(int supplierId, string filter = "");
    }
}
