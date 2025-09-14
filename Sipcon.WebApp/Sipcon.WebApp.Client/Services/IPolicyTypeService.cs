namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IPolicyTypeService
    {

        public Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? Idbrand = null);
        public Task<ApiResponse<PolicyType>> GetPolicyType(int IdPolicyType, int IdUser);
        public Task<ApiResponse<ActionResult>> CreatePolicyType(PolicyType PolicyType, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdatePolicyType(PolicyType PolicyType, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsPolicyType(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportPolicyTypes(int IdSupplier, int IdUser, string Filter = "");
        public Task<ApiResponse<bool>> ImportPolicyTypes(int IdSupplier, int IdUser, MultipartFormDataContent FormData);


    }
}
