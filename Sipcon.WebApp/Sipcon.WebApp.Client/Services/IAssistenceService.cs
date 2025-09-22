namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IAssistenceService
    {

        public Task<ApiResponse<List<Assistence>>> GetAssistences(int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null);
        public Task<ApiResponse<Assistence>> GetAssistence(int IdUser, int IdDealer, int IdAssistence);
        public Task<ApiResponse<ActionResult>> CreateAssistence(Assistence Assistence, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateAssistence(Assistence Assistence, int IdUser);
        public Task<ApiResponse<ActionResult>> ActionsAssistence(List<PostAction> PostActions, int IdUser);
        public Task<ApiResponse<List<byte>>> ExportAssistences(int IdUser, string Filter = "", int? IdDealer = null);


    }
}
