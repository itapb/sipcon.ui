namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class AreaRepository(HttpClient http) : IAreaService
    {
        private readonly HttpClient _http = http;

        // ── GET ALL ───────────────────────────────────────────────────────────
        public async Task<ApiResponse<List<Area>>> GetAreas(
            int userId, int supplierId, int dealerId,
            int rowFrom = 0, string filter = "", bool? active = null)
        {
            ApiResponse<List<Area>>? result;
            try
            {
                var url = $"api/Area/GetAll?userId={userId}&supplierId={supplierId}&dealerId={dealerId}&rowFrom={rowFrom}";
                if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
                if (active.HasValue)               url += $"&active={active.Value}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<Area>>>(url);
                result ??= new ApiResponse<List<Area>>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Area>>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── GET ONE ───────────────────────────────────────────────────────────
        public async Task<ApiResponse<Area>> GetArea(int areaId, int userId)
        {
            ApiResponse<Area>? result;
            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<Area>>(
                    $"api/Area/GetOne?areaId={areaId}&userId={userId}");
                result ??= new ApiResponse<Area>
                {
                    Processed = false,
                    Message   = "La respuesta del servidor no contiene datos."
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Area>
                {
                    Processed = false,
                    Message   = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        // ── SAVE (INSERT si Id == 0, UPDATE si Id > 0 — lo decide el SP) ─────
        public async Task<ApiResponse<ActionResult>> SaveArea(Area area, int userId)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"api/Area/Post?userId={userId}",
                    new List<Area> { area });

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
        public async Task<ApiResponse<ActionResult>> ActionsArea(List<PostAction> postActions, int userId)
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
                    $"api/Area/PostActions?userId={userId}", postActions, options);

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
        public async Task<ApiResponse<List<byte>>> ExportAreas(
            int userId, int supplierId, int dealerId,
            string filter = "", bool? active = null)
        {
            ApiResponse<List<byte>> result;
            try
            {
                var url = $"api/Area/Export?userId={userId}&supplierId={supplierId}&dealerId={dealerId}";
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
