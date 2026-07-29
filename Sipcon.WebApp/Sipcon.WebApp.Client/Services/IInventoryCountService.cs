namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IInventoryCountService
    {

        public Task<ApiResponse<List<InventoryCount>>> GetInventoryCount(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> ExportInventoryCount(int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);

        public Task<ApiResponse<List<InventoryCount>>> GetOneInventoryCount(int IdSupplier, int IdUser, int InventoryCountId);

        public Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetails(int IdSupplier, int IdUser,int inventoryCountId , int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "",int? EstatusId = null);
    }
}
