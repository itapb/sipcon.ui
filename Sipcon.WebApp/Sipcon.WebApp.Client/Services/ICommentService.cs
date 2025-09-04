namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface ICommentService
    {

        public Task<ApiResponse<List<Comment>>> GetComments(int IdRecord, string ModuleName);
        public Task<ApiResponse<ActionResult>> CreateComment(Comment Comment, int IdUser);


    }
}
