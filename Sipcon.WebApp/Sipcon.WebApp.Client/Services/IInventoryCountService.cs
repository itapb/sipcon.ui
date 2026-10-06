namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IInventoryCountService
    {

        public Task<ApiResponse<List<GetInventoryCount>>> GetInventoryCount(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);
        public Task<ApiResponse<List<byte>>> ExportInventoryCount(int IdSupplier, int IdUser, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null);

        public Task<ApiResponse<List<GetInventoryCount>>> GetOneInventoryCount(int IdSupplier, int IdUser, int InventoryCountId);

        public Task<ApiResponse<List<GetCountFull>>> GetInventoryCountDetailByZone(int IdSupplier, int IdUser,int inventoryCountId , int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "",int? EstatusId = null);

        public Task<ApiResponse<List<InventoryCountType>>> GetInventoryCountTypes(int IdUser);

        public Task<ApiResponse<ActionResult>> UpdateInventoryCount(GetInventoryCount InventoryCount, int IdUser);

        public Task<ApiResponse<ActionResult>> ActionsInventoryCount(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsInventoryCountDetail(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<GetInventoryCountDetail>>> GetInventoryCountDetail(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0, string Filter = "", string DateFrom = "", string DateTo = "", int? EstatusId = null, int? ZoneId = null, bool? Assign = null);

        public Task<ApiResponse<List<byte>>> ExportPdfInventoryCount(int inventoryId, List<int> formIds, int supplierId, int userId);

        public Task<ApiResponse<List<ZoneOption>>> GetZoneCount(int IdUser, int SupplierId);

        public Task<ApiResponse<List<CountSummary>>> GetCountSummary(int IdSupplier, int IdUser, int inventoryCountId, int RowFrom = 0);


    }
}
