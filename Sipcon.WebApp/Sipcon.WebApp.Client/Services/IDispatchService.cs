namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IDispatchService
    {
        // Delete
        Task<ApiResponse<ActionResult>> DeleteDispatch(int IdDispatch);

        Task<ApiResponse<ActionResult>> DeleteDispatchTxt(int idControl, string vinnerCode);

    }
}
