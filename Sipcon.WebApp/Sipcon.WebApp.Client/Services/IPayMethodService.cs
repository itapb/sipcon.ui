namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    

    public interface IPayMethodService
    {

        public Task<ApiResponse<List<PayMethod>>> GetPayMethods(int IdUser);

    }
}
