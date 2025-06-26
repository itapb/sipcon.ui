namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IAttachmentService
    {

        public Task<ApiResponse<List<Attachment>>> GetAttachments(int IdRecord, string ModuleName);
        public Task<ApiResponse<List<byte>>> GetAttachment(int IdAttachment, int IdUser);
        public Task<ApiResponse<bool>> CreateAttachment(int IdRecord, string ModuleName, int IdUser, MultipartFormDataContent FormData);
        public Task<ApiResponse<bool>> DeleteAttachment(int IdAttachment, int IdUser);

    }
}
