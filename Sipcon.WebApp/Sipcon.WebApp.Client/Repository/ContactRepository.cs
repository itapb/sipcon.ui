namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class ContactRepository(HttpClient http) : IContactService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<Contact>> GetContactByVAT(string Vat, string ContactType)
        {
            ApiResponse<Contact>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Contact>>($"api/Contact/GetByVat?vat={Vat}&contactType={ContactType}");

                result = (result is null) ? new ApiResponse<Contact>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Contact>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<Contact>> GetContact(int Id)
        {
            ApiResponse<Contact>? result;
            try
            {
                var Listresult = await _http.GetFromJsonAsync<List<Contact>>($"api/Contact/GetOne?contactId={Id}");

                result = Listresult is not null ? new ApiResponse<Contact>()
                {
                    Processed = true,
                    Message = "",
                    Data = Listresult.FirstOrDefault() ?? new Contact()
                } : new ApiResponse<Contact>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                };  

            }
            catch (Exception ex)
            {
                result = new ApiResponse<Contact>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

    }

}
