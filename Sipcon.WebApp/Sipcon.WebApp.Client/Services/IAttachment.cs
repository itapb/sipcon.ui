namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IAttachmentService
    {

        public Task<ApiResponse<List<Attachment>>> GetAttachments(int IdRecord, int IdModule);
        public Task<ApiResponse<Attachment>> GetAttachment(int IdAttachment, int IdUser);
        public Task<ApiResponse<bool>> CreateAttachment(int IdRecord, int IdModule, int IdUser, MultipartFormDataContent FormData);
        public Task<ApiResponse<bool>> DeleteAttachment(int IdAttachment, int IdUser);

    }
}
