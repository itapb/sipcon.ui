namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IKardexService
    {

        public Task<ApiResponse<List<Kardex>>> GetKardex(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "");
        public Task<ApiResponse<List<byte>>> ExportKardex(int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "");
    }
}
