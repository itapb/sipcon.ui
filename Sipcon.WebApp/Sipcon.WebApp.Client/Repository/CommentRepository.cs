namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;



    public class CommentRepository(HttpClient http) : ICommentService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Comment>>> GetComments(int IdRecord, string ModuleName)
        {
            ApiResponse<List<Comment>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<Comment>>>($"api/Comment/GetAll?moduleName={ModuleName}&recordId={IdRecord}");


                result = result is null ? new ApiResponse<List<Comment>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Comment>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Comment>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Comment>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateComment(Comment Comment, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {

                var _comment = new CommentUp()
                {
                    Id = Comment.Id,
                    IsActive = Comment.IsActive,
                    Content = Comment.Content,
                    RecordId = Comment.RecordId,
                    ModuleName = Comment.ModuleName

                };


                var response = await _http.PostAsJsonAsync($"api/Comment/PostComment?userId={IdUser}", _comment);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear el Comment: {response.StatusCode} - {response.ReasonPhrase}");
                }

                result = await response.Content.ReadFromJsonAsync<ApiResponse<List<ActionResult>>>();
                result = (result is null) ? new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;
            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<ActionResult>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
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


    }

}
