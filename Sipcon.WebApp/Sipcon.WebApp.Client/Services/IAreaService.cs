namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IAreaService
    {
        // GetAll — requiere userId, supplierId, dealerId igual que el endpoint
        Task<ApiResponse<List<Area>>> GetAreas(int userId, int supplierId, int dealerId,
                                               int rowFrom = 0, string filter = "", bool? active = null);

        // GetOne
        Task<ApiResponse<Area>> GetArea(int areaId, int userId);
         
        Task<ApiResponse<ActionResult>> SaveArea(Area area, int userId);

        // PostActions — Activate / Deactivate
        Task<ApiResponse<ActionResult>> ActionsArea(List<PostAction> postActions, int userId);

        // Export
        Task<ApiResponse<List<byte>>> ExportAreas(int userId, int supplierId, int dealerId,
                                                  string filter = "", bool? active = null);
    }
}
