namespace Sipcon.WebApp.Client.Repository
{

    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class LicenseRepository(HttpClient http) : ILicenseService
    {
        private readonly HttpClient _http = http;
        
        public async Task<ApiResponse<List<License>>> GetLicenses(int IdUser, int Idsupplier, int RowFrom = 0, string Filter = "" )
        {
            ApiResponse<List<License>>? result;

            try
            {
                var url = $"api/License/GetAll?rowFrom={RowFrom}&userId={IdUser}&supplierId={Idsupplier}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<License>>>(url);

                result = (result is null) ? new ApiResponse<List<License>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<License>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<License>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<License>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<License>> GetLicense(int IdLicense, int IdUser)
        {
            ApiResponse<License>? result;
            try
            {
                var url = $"api/License/GetOne?licenseid={IdLicense}&userId={IdUser}";

                var resultlist = await _http.GetFromJsonAsync<ApiResponse<List<License>>>(url);
                result = (resultlist is null) ? new ApiResponse<License>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."

                } : new ApiResponse<License>()
                {
                    Processed = resultlist.Processed,
                    Total = resultlist.Total,
                    Message = resultlist.Message,
                    Data = resultlist.Data.FirstOrDefault() ?? new License()

                };

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<License>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<License>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<License>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

        public async Task<ApiResponse<List<LicenseType>>> GetLicenseType(int IdUser)
        {
            ApiResponse<List<LicenseType>>? result;

            try
            {
                var url = $"api/License/GetLicenseType";

                result = await _http.GetFromJsonAsync<ApiResponse<List<LicenseType>>>(url);

                result = (result is null) ? new ApiResponse<List<LicenseType>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<LicenseType>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<LicenseType>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<LicenseType>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<ActionResult>> CreateLicense(License License, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<LicenseUp> _licenseList = ([]);
            try
            {
                var _license = new LicenseUp()
                {

                    Id = License.Id,
                    IsActive = License.IsActive,
                    SupplierId = License.SupplierId,
                    Description = License.Description,
                    TypeId = License.TypeId ?? 0,
                    ExpirationDate = License.ExpirationDate ?? DateTime.Now
                };

                _licenseList.Add(_license);

                var url = $"api/License/PostLicense?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _licenseList);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<ActionResult>> UpdateLicense(License License, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<LicenseUp> _licenseList  = ([]);
            try
            {

                var _license = new LicenseUp()
                {

                    Id = License.Id,
                    IsActive = License.IsActive,
                    SupplierId = License.SupplierId,
                    Description = License.Description,
                    TypeId = License.TypeId ?? 0,
                    ExpirationDate = License.ExpirationDate ?? DateTime.Now
                };

                _licenseList.Add(_license);
                
                var url = $"api/License/PostLicense?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, _licenseList);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };
                
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

        public async Task<ApiResponse<ActionResult>> ActionsLicense(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                var url = $"api/License/PostActions?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, PostActions, options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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


        /// <summary>
        /// DETALLES DE LICENCIA
        /// </summary>

        public async Task<ApiResponse<List<LicenseDetail>>> GetLicenseDetails(int IdUser, int IdLicense, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<LicenseDetail>>? result;

            try
            {
                var url = $"api/License/GetDetails?rowFrom={RowFrom}&licenseId={IdLicense}&userId={IdUser}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<LicenseDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<LicenseDetail>>> GetLicenseDetailsBy(int IdUser, string Filter)
        {
            ApiResponse<List<LicenseDetail>>? result;

            try
            {
                var url = $"api/License/GetDetailBy?userId={IdUser}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<LicenseDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<LicenseDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<ActionResult>> CreateLicenseDetail(LicenseDetail Detail, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<LicenseDetailUp> _licenseList = ([]);
            try
            {
                var _license = new LicenseDetailUp()
                {

                    Id = Detail.Id,
                    IsActive = Detail.IsActive,
                    LicenseId = Detail.LicenseId,
                    VIN = Detail.VIN
                };

                _licenseList.Add(_license);

                var url = $"api/License/PostLicenseDetails?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _licenseList);

                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<ActionResult>> UpdateLicenseDetail(LicenseDetail Detail, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<LicenseDetailUp> _licenseList = ([]);
            try
            {
                var _license = new LicenseDetailUp()
                {

                    Id = Detail.Id,
                    IsActive = Detail.IsActive,
                    LicenseId = Detail.LicenseId,
                    VIN = Detail.VIN
                };

                _licenseList.Add(_license);
                
                var url = $"api/License/PostLicenseDetails?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, _licenseList);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<ActionResult>> ActionsLicenseDetail(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                var url = $"api/License/PostDetailsActions?userId={IdUser}";

                var response = await _http.PostAsJsonAsync(url, PostActions, options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<ActionResult>> DeleteLicenseDetail(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<ActionResult>? result;
            List<PostAction> PostActionList = ([]);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true
                };

                var url = $"api/License/DeleteLicenseDetail?userId={IdUser}";
                
                var response = await _http.PostAsJsonAsync(url, PostActions, options);
                result = await response.Content.ReadFromJsonAsync<ApiResponse<ActionResult>>();
                result = (result is null) ? new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = "El servidor devolvió una respuesta vacía."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<ActionResult>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

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

        public async Task<ApiResponse<bool>> ImportLicenseDetails(int IdUser, int IdLicense, MultipartFormDataContent FormData)
        {
            ApiResponse<bool> result;

            try
            {
                var url = $"api/License/ImportLicenseDetails?userId={IdUser}&licenseId={IdLicense}";
                var response = await _http.PostAsync(url, FormData);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = false,
                        Message = "Error al Importar.",
                        Data = false
                    };
                }
                else
                {
                    result = new ApiResponse<bool>()
                    {
                        Processed = true,
                        Message = "Importacion exitosa.",
                        Data = true
                    };
                }


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

        public async Task<ApiResponse<List<byte>>> ExportLicenseDetails(int IdUser, int IdLicense, string Filter = "")
        {
            ApiResponse<List<byte>> result; 
            string fileUrl = string.Empty;
            try
            {

                var url = $"api/License/ExportDetails?userId={IdUser}&licenseId={IdLicense}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                var response = await _http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = false,
                        Message = "Error al Exportar ",
                        Data = []
                    };
                }
                else {
                    var fileContent = await response.Content.ReadAsByteArrayAsync();
                    result = new ApiResponse<List<byte>>()
                    {
                        Processed = true,
                        Message = "Exportación exitosa.",
                        Data = fileContent.ToList()
                    };
                }

                
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

        

    }

}
