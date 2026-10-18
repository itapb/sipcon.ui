namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IDispatchService
    {
        // Delete
        Task<ApiResponse<ActionResult>> DeleteDispatch(int IdDispatch);
    }
}
