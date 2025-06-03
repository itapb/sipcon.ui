namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IPolicyService
    {

        public Task<ApiResponse<List<Policy>>> GetPolicys(int IdUser, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<Policy>> GetPolicy(int IdPolicy, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> CreatePolicy(Policy Policy, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdatePolicy(Policy Policy, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsPolicy(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportPolicys(int IdUser, string Filter = "");
        public Task<ApiResponse<List<byte>>> ExportPdfPolicy(int IdUser, int IdPolicy);
        


    }
}
