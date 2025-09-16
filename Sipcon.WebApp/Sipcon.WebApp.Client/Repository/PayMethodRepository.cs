namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class PayMethodRepository(HttpClient http) : IPayMethodService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<PayMethod>>> GetPayMethods(int IdUser)
        {
            ApiResponse<List<PayMethod>>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<PayMethod>>>($"api/PayMethod/GetAll");

                result = result is null ? new ApiResponse<List<PayMethod>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<PayMethod>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }

      
    }

}
