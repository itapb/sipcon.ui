namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IInventoryCountService
    {

        public Task<ApiResponse<List<GetInventoryCount>>> GetInventoryCount(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> ExportInventoryCount(int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);

        public Task<ApiResponse<List<GetInventoryCount>>> GetOneInventoryCount(int IdSupplier, int IdUser, int InventoryCountId);

        public Task<ApiResponse<List<GetCountFull>>> GetInventoryCountDetails(int IdSupplier, int IdUser,int inventoryCountId , int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "",int? EstatusId = null);

        public Task<ApiResponse<List<InventoryCountType>>> GetInventoryCountTypes(int IdUser);

        public Task<ApiResponse<ActionResult>> UpdateInventoryCount(GetInventoryCount InventoryCount, int IdUser);

        public Task<ApiResponse<ActionResult>> ActionsInventoryCount(List<PostAction> PostActions, int IdUser);

    }
}
