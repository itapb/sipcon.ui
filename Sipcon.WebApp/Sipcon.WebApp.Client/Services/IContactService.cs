namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IContactService
    {

        public Task<ApiResponse<Contact>> GetContactByVAT(string VAT, int IdUser);
      

    }
}
