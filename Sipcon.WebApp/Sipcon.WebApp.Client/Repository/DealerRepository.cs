namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class DealerRepository(HttpClient http) : IDealerService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Dealer>>> GetDealers(int IdUser, int IdSupplier)
        {
            ApiResponse<List<Dealer>>? result;

            try
            {
            
                var SupplierList = await _http.GetFromJsonAsync<List<Dealer>>($"api/Contact/GetDealers?idSupplier={IdSupplier}");

                result = (SupplierList is null) ? new ApiResponse<List<Dealer>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : new ApiResponse<List<Dealer>>()
                {
                    Processed = true,
                    Data = [],
                };

                if (result.Processed)
                {
                    result.Data.AddRange(SupplierList ?? []);
                }

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Dealer>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Dealer>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Dealer>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }
        public async Task<ApiResponse<Dealer>> GetDealer(int IdDealer, int IdUser) 
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<ApiResponse<ActionResult>> CreateDealer(Dealer Dealer, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<ApiResponse<ActionResult>> UpdateDealer(Dealer Dealer, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");

        }
      

    }

}
