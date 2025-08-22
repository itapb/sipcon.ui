namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    using Sipcon.WebApp.Client.Services;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;



    public class SecurityRepository(HttpClient http) : ISecurityService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<AccessGroup>>> GetAccessGroups(int row, string Filter = "")
        {
            ApiResponse<List<AccessGroup>>? result;

            try
            {
                result = await _http.GetFromJsonAsync<ApiResponse<List<AccessGroup>>>($"api/Security/GetAccessGroup?filter={Filter}&rowFrom={row}");


                result = result is null ? new ApiResponse<List<AccessGroup>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos.",
                    

                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<AccessGroup>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: " , httpEx.Message)
                };
                
            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<AccessGroup>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: " , notSupportedEx.Message)
                };
                
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AccessGroup>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateAccessGroup(AccessGroup AccessGroup, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            try
            {

                var response = await _http.PostAsJsonAsync($"api/Security/PostAccessGroup?userId={IdUser}", AccessGroup);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessGroup: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<ActionResult>>> UpdateAccessGroup(AccessGroup AccessGroup, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;

            try
            {
               
                var response = await _http.PostAsJsonAsync($"api/Security/PostAccessGroup?userId={IdUser}", AccessGroup);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessGroup: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<ActionResult>>> ActionsAccessGroup(List<PostAction> PostActions, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<PostAction> PostActionList = ([]);
            try
            {

                var response = await _http.PostAsJsonAsync($"api/Security/Post_AccessGroup_Actions?userId={IdUser}", PostActions);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessGroup: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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






        /// <summary>
        /// DETALLES ACCIONES
        /// </summary>

        public async Task<ApiResponse<List<AccessGroupDetail>>> GetAccessGroupDetails(int IdgroupAccess, int row, string Filter = "")
        {
            ApiResponse<List<AccessGroupDetail>>? result;

            try
            {
                var url = $"api/Security/GetAccessGroupDetails?groupAccessId={IdgroupAccess}&rowFrom={row}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<AccessGroupDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<AccessGroupDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<AccessGroupDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<AccessGroupDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AccessGroupDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateAccessGroupDetail(AccessGroupDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<AccessGroupDetailUp> _List = ([]);
            try
            {
                var _roleDetail = new AccessGroupDetailUp()
                {
                    AccessGroupId = Detail.AccessGroupId,
                    ModuleId = Detail.ModuleId,
                    ActionId = Detail.ActionId,
                    Assign = Detail.Assign,
                };

                _List.Add(_roleDetail);

                var url = $"api/Security/PostAccessGroupDetails?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _List);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessGroupDetail: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<ActionResult>>> UpdateAccessGroupDetail(AccessGroupDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<AccessGroupDetailUp> _List = ([]);
            try
            {
                var _roleDetail = new AccessGroupDetailUp()
                {
                    AccessGroupId = Detail.AccessGroupId,
                    ModuleId = Detail.ModuleId,
                    ActionId = Detail.ActionId,
                    Assign = Detail.Assign,
                };

                _List.Add(_roleDetail);

                var url = $"api/Security/PostAccessGroupDetails?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _List);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessGroupDetail: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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



        /// <summary>
        /// DETALLES USUARIOS
        /// </summary>

        public async Task<ApiResponse<List<AccessUserDetail>>> GetAccessUserDetails(int IdGroupAccess, int row, bool IsAssign, string Filter = "")
        {
            ApiResponse<List<AccessUserDetail>>? result;

            try
            {
                var url = $"api/Security/GetAccessUserbyGroup?accessGroupId={IdGroupAccess}&rowFrom={row}&assign={IsAssign}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<AccessUserDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<AccessUserDetail>>> GetAccessGroupUser(int IdAccessUser, int row, bool? IsAssign, string Filter = "")
        {
            ApiResponse<List<AccessUserDetail>>? result;

            try
            {
                var url = $"api/Security/GetAccessGroupUser?rowFrom={row}&userId={IdAccessUser}";
                url = IsAssign is null ? url : $"{url}&assign={IsAssign}";
                url = string.IsNullOrEmpty(Filter) ? url : $"{url}&filter={Filter}";

                result = await _http.GetFromJsonAsync<ApiResponse<List<AccessUserDetail>>>(url);

                result = (result is null) ? new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : result;

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<AccessUserDetail>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }

        public async Task<ApiResponse<List<ActionResult>>> CreateAccessUserDetail(AccessUserDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<AccessUserDetailUp> _List = ([]);
            try
            {
                var _detail = new AccessUserDetailUp()
                {
                    UserId = Detail.UserId,
                    AccessGroupId = Detail.AccessGroupId,
                    Assign = Detail.Assign
                };
                _List.Add(_detail);

                var url = $"api/Security/PostAccessGroupUser?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _List);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al crear el AccessUserDetail: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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

        public async Task<ApiResponse<List<ActionResult>>> UpdateAccessUserDetail(AccessUserDetail Detail, int IdUser)
        {
            ApiResponse<List<ActionResult>>? result;
            List<AccessUserDetailUp> _List = ([]);
            try
            {
                var _detail = new AccessUserDetailUp()
                {
                    UserId = Detail.UserId,
                    AccessGroupId = Detail.AccessGroupId,
                    Assign = Detail.Assign
                };
                _List.Add(_detail);

                var url = $"api/Security/PostAccessGroupUser?userId={IdUser}";
                var response = await _http.PostAsJsonAsync(url, _List);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Error al modificar AccessUserDetail: {response.StatusCode.ToString()} - {response.ReasonPhrase}");
                    }

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
