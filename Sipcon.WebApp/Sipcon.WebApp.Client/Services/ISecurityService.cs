namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface ISecurityService
    {

        public Task<ApiResponse<List<AccessGroup>>> GetAccessGroups(int row, string Filter = "");
        public Task<ApiResponse<List<ActionResult>>> CreateAccessGroup(AccessGroup AccessGroup, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateAccessGroup(AccessGroup AccessGroup, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsAccessGroup(List<PostAction> PostActions, int IdUser);



        public Task<ApiResponse<List<AccessGroupDetail>>> GetAccessGroupDetails(int IdGroupAccess, int row, string Filter = "");
        public Task<ApiResponse<List<ActionResult>>> CreateAccessGroupDetail(AccessGroupDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateAccessGroupDetail(AccessGroupDetail Detail, int IdUser);


        public Task<ApiResponse<List<AccessUserDetail>>> GetAccessUserDetails(int IdGroupAccess, int row, bool IsAssign, string Filter = "");
        public Task<ApiResponse<List<AccessUserDetail>>> GetAccessGroupUser(int IdAccessUser, int row, bool? IsAssign, string Filter = "");
        public Task<ApiResponse<List<ActionResult>>> CreateAccessUserDetail(AccessUserDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateAccessUserDetail(AccessUserDetail Detail, int IdUser);


    }
}
