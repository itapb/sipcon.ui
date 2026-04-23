namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IRateService
    {
        public Task<ApiResponse<List<Rate>>> GetRates(int? rowFrom = null, string? filter = null);
        public Task<ApiResponse<ActionResult>> SaveRate(Rate Rate);
        public Task<ApiResponse<List<byte>>> ExportRates();
    }
}