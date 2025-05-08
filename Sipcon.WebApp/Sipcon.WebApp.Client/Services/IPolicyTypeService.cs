namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IPolicyTypeService
    {

        public Task<ApiResponse<List<PolicyType>>> GetPolicyTypes(int IdUser, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<PolicyType>> GetPolicyType(int IdPolicyType, int IdUser);
        public Task<bool> CreatePolicyType(PolicyType PolicyType, int IdUser);
        public Task<bool> UpdatePolicyType(PolicyType PolicyType, int IdUser);


    }
}
