namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface ICommentService
    {

        public Task<ApiResponse<List<Comment>>> GetComments(int IdUser, int IdDealer, int RowFrom = 0, string Filter = "");
        public Task<ApiResponse<List<ActionResult>>> CreateComment(Comment Comment, int IdUser);


    }
}
