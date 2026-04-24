namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFeatureValueTypeService
    {
        Task<ApiResponse<List<FeatureValueType>>> GetFeatureValueTypes(int userId);
    }
}
