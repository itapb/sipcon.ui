namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;


    public class ModuleRepository(HttpClient http) : IModuleService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Module>>> GetModules(int IdUser, string Module = " ")
        {
            ApiResponse<List<Module>> result;
            try
            {
                var Modules = await _http.GetFromJsonAsync<List<Module>>($"api/Module/GetAll?moduleName={Module}&userId={IdUser}");

                result = (Modules is null) ? new ApiResponse<List<Module>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : new ApiResponse<List<Module>>()
                {
                    Processed = true,
                    Data = [],
                };

                if (result.Processed)
                {
                    result.Data.AddRange(Modules ?? []);
                }

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Module>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }
        public async Task<Module> GetModule(int IdModule, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<bool> CreateModule(Module Module, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");

        }
        public async Task<bool> UpdateModule(Module Module, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");

        }

        public async Task<ApiResponse<List<ActionModule>>> GetStatusByModule(int IdUser, string Module = "")
        {
            ApiResponse<List<ActionModule>> result;
            try
            {
                var Modules = await _http.GetFromJsonAsync<List<ActionModule>>($"api/Module/GetActionByModule?moduleName={Module}&userId={IdUser}");

                result = (Modules is null) ? new ApiResponse<List<ActionModule>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : new ApiResponse<List<ActionModule>>()
                {
                    Processed = true,
                    Data = [],
                };

                if (result.Processed)
                {
                    result.Data.AddRange(Modules ?? []);
                }

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<ActionModule>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;
        }

    }

}
