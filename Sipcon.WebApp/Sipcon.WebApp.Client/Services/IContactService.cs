namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    public interface IContactService
    {

        public Task<ApiResponse<Contact>> GetContactByVAT(string VAT, string ContactType);
        public Task<ApiResponse<Contact>> GetContact(int Id);



    }
}
