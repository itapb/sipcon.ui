namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFaseService
    {
        Task<ApiResponse<List<Fase>>> GetFases(int userId, int supplierId, int dealerId,
                                               int rowFrom = 0, string filter = "", bool? active = null);
        Task<ApiResponse<Fase>>           GetFase(int faseId, int userId);
        Task<ApiResponse<ActionResult>>   SaveFase(Fase fase, int userId);
        Task<ApiResponse<ActionResult>>   ActionsFase(List<PostAction> postActions, int userId);
        Task<ApiResponse<List<byte>>>     ExportFases(int userId, int supplierId, int dealerId,
                                                      string filter = "", bool? active = null);
    }
}
