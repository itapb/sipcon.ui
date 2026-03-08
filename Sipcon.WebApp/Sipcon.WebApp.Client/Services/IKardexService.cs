namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IKardexService
    {

        public Task<ApiResponse<List<Kardex>>> GetKardex(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "");
    }
}
