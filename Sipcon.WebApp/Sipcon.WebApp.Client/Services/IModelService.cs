namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IModelService
    {
     
        public Task<ApiResponse<List<Model>>> GetModels(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<Model>> GetModel(int IdModel, int IdUser); 
        public Task<ApiResponse<ActionResult>> CreateModel(Model Model, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateModel(Model Model, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsModel(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportModels(int IdSupplier, int IdUser, string Filter = "");
        public Task<ApiResponse<ActionResult>> ImportModels(int IdSupplier, int IdUser, MultipartFormDataContent FormData);
        

    }
}
