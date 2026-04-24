namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFeatureOptionService
    { 
        Task<ApiResponse<List<FeatureOption>>> GetFeatureOptions(int userId, int featureId);
        Task<ApiResponse<ActionResult>>        SaveFeatureOptions(List<FeatureOption> options, int userId);
    }
}
