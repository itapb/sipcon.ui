namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IModelService
    {
     
        public Task<ApiResponse<List<Model>>> GetModels(int IdUser, int RowFrom = 0, string Filter = " ");
        public Task<ApiResponse<Model>> GetModel(int IdModel, int IdUser); 
        public Task<ApiResponse<List<ActionResult>>> CreateModel(Model Model, int IdUser);
        public Task<ApiResponse<List<ActionResult>>> UpdateModel(Model Model, int IdUser);
        
    }
}
