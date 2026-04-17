namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class RateRepository(HttpClient http) : IRateService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<List<Rate>>> GetRates(int? rowFrom = null, string? filter = null)
        {
            ApiResponse<List<Rate>>? result;
            try
            {
                var url = $"api/Rate/GetAll";
                if (rowFrom.HasValue)
                    url += $"?rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter))
                    url += $"{(rowFrom.HasValue ? "&" : "?")}filter={filter}";

                var response = await _http.GetFromJsonAsync<ApiResponse<List<Rate>>>(url);

                result = response ?? new ApiResponse<List<Rate>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Rate>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<ActionResult>> CreateRate(Rate Rate)
        {
            ApiResponse<ActionResult>? result;
            List<Rate> rateList = [];
            try
            {
                rateList.Add(Rate);
                var response = await _http.PostAsJsonAsync($"api/Rate/PostRates", rateList);
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

        public async Task<ApiResponse<ActionResult>> UpdateRate(Rate Rate)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var url = $"api/Rate/Update_Rate?id={Rate.Id}&nRate={Rate.NRate}";
                var response = await _http.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    var updatedRate = await response.Content.ReadFromJsonAsync<Rate>();
                    result = new ApiResponse<ActionResult>()
                    {
                        Processed = true,
                        Data = null,
                        Message = "Tasa actualizada correctamente"
                    };
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    result = new ApiResponse<ActionResult>()
                    {
                        Processed = false,
                        Message = string.Concat("Error al actualizar: ", errorMessage)
                    };
                }
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

        public async Task<ApiResponse<List<byte>>> ExportRates()
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Rate/Export";
                var response = await _http.GetAsync(url);
                var fileContent = await response.Content.ReadAsByteArrayAsync();

                result = (fileContent is null) ? new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = "Error al Exportar Data.",
                    Data = []
                } : new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "",
                    Data = fileContent.ToList()
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = []
                };
            }
            return result;
        }
    }
}