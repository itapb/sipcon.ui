namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Enum;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Microsoft.Extensions.Options;


    public class KardexRepository(HttpClient http) : IKardexService
    {
        private readonly HttpClient _http = http;

        
        public async Task<ApiResponse<List<Kardex>>> GetKardex(int IdSupplier, int IdUser, int RowFrom = 0, string Filter = "", int? IdDealer = null, string DateFrom = "", string DateTo = "")
        {
            ApiResponse<List<Kardex>>? result;

            try
            {
                var url = $"api/GetKardex?supplierId={IdSupplier}&userId={IdUser}&rowFrom={RowFrom}";
                url = (IdDealer.HasValue ) ? $"{url}&dealerId={IdDealer}" : url;
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";
                url = string.IsNullOrEmpty(DateFrom) ? url : $"{url}&fromDate={DateFrom}";
                url = string.IsNullOrEmpty(DateTo) ? url : $"{url}&upToDate={DateTo}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Kardex>>>(url);
                

                result = (result is null) ? new ApiResponse<List<Kardex>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Kardex>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

      

    }

}
