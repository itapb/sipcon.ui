namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFeatureTypeService
    {
        Task<ApiResponse<List<FeatureType>>> GetFeatureTypes(int userId, int supplierId, int dealerId,
                                                             int rowFrom = 0, string filter = "", bool? active = null);
        Task<ApiResponse<FeatureType>>        GetFeatureType(int featureTypeId, int userId);
        Task<ApiResponse<ActionResult>>       SaveFeatureType(FeatureType featureType, int userId);
        Task<ApiResponse<ActionResult>>       ActionsFeatureType(List<PostAction> postActions, int userId);
        Task<ApiResponse<List<byte>>>         ExportFeatureTypes(int userId, int supplierId, int dealerId,
                                                                 string filter = "", bool? active = null);
    }
}
