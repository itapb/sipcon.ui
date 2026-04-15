namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFeatureService
    {
        Task<ApiResponse<List<Feature>>> GetFeatures(int userId, int supplierId, int? dealerId,
                                                     int rowFrom = 0, string filter = "", bool? active = null);
        Task<ApiResponse<Feature>>        GetFeature(int featureId, int userId);
        Task<ApiResponse<ActionResult>>   SaveFeature(Feature feature, int userId);
        Task<ApiResponse<ActionResult>>   ActionsFeature(List<PostAction> postActions, int userId);
        Task<ApiResponse<List<byte>>>     ExportFeatures(int userId, int supplierId, int? dealerId,
                                                         string filter = "", bool? active = null);
    }
}
