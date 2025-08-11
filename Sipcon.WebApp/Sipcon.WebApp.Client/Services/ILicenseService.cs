namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using System.ComponentModel;

    public interface ILicenseService
    {
        public Task<ApiResponse<List<Models.License>>> GetLicenses(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<Models.License>> GetLicense(int IdLicense, int IdUser);
        public Task<ApiResponse<List<LicenseType>>> GetLicenseType(int IdUser);
        public Task<ApiResponse<List<ActionResult>>> CreateLicense(Models.License License, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateLicense(Models.License License, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsLicense(List<PostAction> PostActions, int IdUser);


        public Task<ApiResponse<List<LicenseDetail>>> GetLicenseDetails(int IdUser, int IdLicense, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<List<LicenseDetail>>> GetLicenseDetailsBy(int IdUser, string Filter);
        public Task<ApiResponse<List<ActionResult>>> CreateLicenseDetail(LicenseDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateLicenseDetail(LicenseDetail Detail, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> ActionsLicenseDetail(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> DeleteLicenseDetail(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<bool>> ImportLicenseDetails(int IdUser, int IdLicense, MultipartFormDataContent FormData);
        public Task<ApiResponse<List<byte>>> ExportLicenseDetails(int IdUser, int IdLicense, string Filter = "");
        

    }
}
