namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.ComponentModel.DataAnnotations;

    public class DemandRepository(HttpClient http) : IDemandService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<ActionResult>> CreateDemand(Demand demand, int IdUser)
        {
            ApiResponse<ActionResult>? result;
   
            try
            {

                var response = await _http.PostAsJsonAsync($"api/Part/PostDemand?userId={IdUser}", demand);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };

            }
            return result;

        }
    }

}
