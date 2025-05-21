namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IPolicyTypeService
    {

        public Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdUser, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<PolicyType>> GetPolicyType(int IdPolicyType, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> CreatePolicyType(PolicyType PolicyType, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdatePolicyType(PolicyType PolicyType, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsPolicyType(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportPolicyTypes(int IdUser, string Filter = "");
        public Task<ApiResponse<bool>> ImportPolicyTypes(int IdUser, MultipartFormDataContent FormData);


    }
}
