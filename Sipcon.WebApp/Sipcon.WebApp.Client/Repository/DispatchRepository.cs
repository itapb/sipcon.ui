namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class DispatchRepository(HttpClient http) : IDispatchService
    {
        private readonly HttpClient _http = http;

        // ── DELETE ───────────────────────────────────────────────────────────
        public async Task<ApiResponse<ActionResult>> DeleteDispatch(int IdDispatch)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/InvoiceControl/DeleteDispatch?IdDispatch={IdDispatch}",
                    new { }
                );

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<ActionResult>> DeleteDispatchTxt(int idControl, string vinnerCode)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/InvoiceControl/DeleteDispatchedControlTxt?idControl={idControl}&vinnerCode={vinnerCode}",
                    new { }
                );

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }
    }
}
