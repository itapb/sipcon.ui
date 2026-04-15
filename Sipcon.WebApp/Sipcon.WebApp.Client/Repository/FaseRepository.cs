namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class FaseRepository(HttpClient http) : IFaseService
    {
        private readonly HttpClient _http = http;

        // ── GET ALL ───────────────────────────────────────────────────────────
        public async Task<ApiResponse<List<Fase>>> GetFases(
            int userId, int supplierId, int dealerId,
            int rowFrom = 0, string filter = "", bool? active = null)
        {
            ApiResponse<List<Fase>>? result;
            try
            {
                var url = $"api/Fase/GetAll?userId={userId}&supplierId={supplierId}&dealerId={dealerId}&rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Fase>>>(url);
                result ??= new ApiResponse<List<Fase>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Fase>>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── GET ONE ───────────────────────────────────────────────────────────
        public async Task<ApiResponse<Fase>> GetFase(int faseId, int userId)
        {
            ApiResponse<Fase>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Fase>>(
                    $"api/Fase/GetOne?fasesId={faseId}&userId={userId}");
                result ??= new ApiResponse<Fase>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Fase>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── SAVE (INSERT si Id == 0, UPDATE si Id > 0) ────────────────────────
        public async Task<ApiResponse<ActionResult>> SaveFase(Fase fase, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/Fase/Post?userId={userId}",
                    new List<Fase> { fase });

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── ACTIONS (Activate / Deactivate) ───────────────────────────────────
        public async Task<ApiResponse<ActionResult>> ActionsFase(List<PostAction> postActions, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy     = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition   = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented            = true
                };

                var response = await _http.PostAsJsonAsync(
                    $"api/Fase/PostActions?userId={userId}", postActions, options);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result ??= new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = "El servidor devolvió una respuesta vacía."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<ActionResult>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── EXPORT ────────────────────────────────────────────────────────────
        public async Task<ApiResponse<List<byte>>> ExportFases(
            int userId, int supplierId, int dealerId,
            string filter = "", bool? active = null)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Fase/Export?userId={userId}&supplierId={supplierId}&dealerId={dealerId}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                var response    = await _http.GetAsync(url);
                var fileContent = await response.Content.ReadAsByteArrayAsync();

                result = fileContent is null || fileContent.Length == 0
                    ? new ApiResponse<List<byte>> { Processed = false, Message = "Error al exportar data.", Data = [] }
                    : new ApiResponse<List<byte>> { Processed = true,  Message = string.Empty, Data = fileContent.ToList() };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<byte>>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data      = []
                };
            }
            return result;
        }
    }
}
