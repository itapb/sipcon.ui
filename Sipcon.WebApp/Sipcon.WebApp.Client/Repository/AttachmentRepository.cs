namespace Sipcon.WebApp.Client.Repository
{
    using Microsoft.Extensions.Options;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Reflection;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class AttachmentRepository(HttpClient http) : IAttachmentService
    {
        private readonly HttpClient _http = http;

        
        public async Task<ApiResponse<List<Attachment>>> GetAttachments(int IdRecord, string ModuleName)
        {
            ApiResponse<List<Attachment>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<Attachment>>>($"api/Attachment/GetAll?moduleName={ModuleName}&recordId={IdRecord}");

                result = (result is null) ? new ApiResponse<List<Attachment>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Attachment>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<byte>>> GetAttachment(int IdAttachment, int IdUser) 
        {
            ApiResponse<List<byte>> result;
            try
            {
                var response = await _http.GetAsync($"api/Attachment/GetOne?userId={IdUser}&attachmentId={IdAttachment}");
                
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

        public async Task<ApiStreamResponse> GetAttachmentPreview(int IdAttachment, int IdUser)
        {
            ApiStreamResponse result;
            try
            {
                var response = await _http.GetAsync($"api/Attachment/GetPreview?userId={IdUser}&attachmentId={IdAttachment}");

                var fileContent = await response.Content.ReadAsStreamAsync();

                result = (fileContent is null) ? new ApiStreamResponse()
                {
                    Processed = false,
                    Message = "Error al Exportar Data."
                } : new ApiStreamResponse()
                {
                    Processed = true,
                    Message = "",
                    File = fileContent
                };

            }
            catch (Exception ex)
            {
                result = new ApiStreamResponse()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;
        }

        public async Task<ApiResponse<List<ActionResult>>> CreateAttachment(int IdRecord, string ModuleName, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {
                var Timeout = TimeSpan.FromSeconds(50); // Timeout value is 50 seconds
                using (var cts = new CancellationTokenSource(Timeout))
                {
                    var url = $"api/Attachment/PostAttachments?userId={IdUser}&recordId={IdRecord}&moduleName={ModuleName}";
                    var response = await _http.PostAsync(url, FormData, cts.Token).ConfigureAwait(false);

                    result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                    result = (result is null) ? new ApiResponse<List<ActionResult>>()
                    {
                        Processed = false,
                        Message = "El servidor devolvió una respuesta vacía."
                    } : result;
                }
                
            }
            catch (OperationCanceledException ex)
            {
                // Handle the cancellation gracefully
                Console.WriteLine($"Operation was cancelled: {ex.Message}");
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Termino el tiempo de espera: 50 Segundos... ", ex.Message)
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<ActionResult>> DeleteAttachment(int IdAttachment, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            try
            {
                string? _assistence = null;
                var response = await _http.PostAsJsonAsync($"api/Attachment/Delete_Attachment?userId={IdUser}&attachmentId={IdAttachment}", _assistence);
                
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
