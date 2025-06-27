namespace Sipcon.WebApp.Client.Repository
{
    using Microsoft.Extensions.Options;
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
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
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Attachment>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Attachment>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Export Attachment: {response.StatusCode} - {response.ReasonPhrase}");
                }

                var fileContent = await response.Content.ReadAsByteArrayAsync();
                result = new ApiResponse<List<byte>>()
                {
                    Processed = true,
                    Message = "Exportación exitosa.",
                    Data = fileContent.ToList()
                };

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = []
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<byte>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = []
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

        public async Task<ApiResponse<bool>> CreateAttachment(int IdRecord, string ModuleName, int IdUser, MultipartFormDataContent FormData)
        {
            ApiResponse<bool> result;
            try
            {
                var response = await _http.PostAsync($"api/Attachment/PostAttachment?userId={IdUser}&recordId={IdRecord}&moduleName={ModuleName}", FormData);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Crear Attachment: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = new ApiResponse<bool>()
                {
                    Processed = true,
                    Message = "Importacion exitosa.",
                    Data = true
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = false
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = false
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = false
                };
            }

            return result;

        }

        public async Task<ApiResponse<bool>> DeleteAttachment(int IdAttachment, int IdUser)
        {
            ApiResponse<bool> result;
            try
            {
                var response = await _http.PostAsync($"api/Attachment/Delete_Attachment?userId={IdUser}&attachmentId={IdAttachment}", null);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error Eliminar Attachment: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = new ApiResponse<bool>()
                {
                    Processed = true,
                    Message = "Importacion exitosa.",
                    Data = true
                };
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message),
                    Data = false
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                    Data = false
                };
            }
            catch (Exception ex)
            {
                result = new ApiResponse<bool>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message),
                    Data = false
                };
            }

            return result;

        }

    }

}
