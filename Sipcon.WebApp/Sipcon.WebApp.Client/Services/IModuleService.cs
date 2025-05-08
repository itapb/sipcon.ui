namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    

    public interface IModuleService
    {

        public Task<ApiResponse<List<Module>>> GetModules(int IdUser, string Module = "");
        public Task<Module> GetModule(int IdModule, int IdUser);
        public Task<bool> CreateModule(Module Module, int IdUser);
        public Task<bool> UpdateModule(Module Module, int IdUser);


    }
}
