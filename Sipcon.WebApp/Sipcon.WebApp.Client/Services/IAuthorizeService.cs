namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Enum;
    using Sipcon.WebApp.Client.Models;
    public interface IAuthorizeService
    {

        public Task Login(LoginResponse token);
        public Task Logout();
        public Task<bool> IsUserAuthenticated();
        public Task<List<UserModule>> GetUserRoleAsync();
        public Task<List<UserType>> GetUserDealerAsync();
        public Task<List<UserType>> GetUserSupplierAsync();
        public Task<User> GetUserAsync();
        public Task<int> GetSelectedDealerAsync();
        public Task<int> GetSelectedSupplierAsync();
        public Task SetValueSessionStorage<T>(T data, ValuesKey key);
        public Task RefreshStaticVariables();
    }
}
