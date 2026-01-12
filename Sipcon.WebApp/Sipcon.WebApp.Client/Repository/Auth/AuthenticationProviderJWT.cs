using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Sipcon.WebApp.Client.Enum;
using Sipcon.WebApp.Client.Helper;
using Sipcon.WebApp.Client.Models;
using Sipcon.WebApp.Client.Services;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Sipcon.WebApp.Client.Repository.Auth
{
    public class AuthenticationProviderJWT : AuthenticationStateProvider, IAuthorizeService
    {
        private readonly HttpClient _http;
        private readonly ISessionStorageService _jsSessionStorage;
        private readonly UserSession _session;

        private static AuthenticationState Anonimo => new(new ClaimsPrincipal(new ClaimsIdentity()));

        public AuthenticationProviderJWT(ISessionStorageService jsSessionStorageService, HttpClient httpClient, UserSession session)
        {
            _http = httpClient;
            _jsSessionStorage = jsSessionStorageService;
            _session = session;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsSessionStorage.GetValue<string>(ValuesKey.TOKENKEY);

            if (string.IsNullOrEmpty(token))
                return Anonimo;

            return BuildAuthenticationState(token);
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim>? ParseClaimsFromJwt(string token)
        {
            var claims = new List<Claim>();
            var payload = token.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            claims.AddRange(keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));

            if (keyValuePairs!.TryGetValue("role", out var roleValue))
                claims.Add(new Claim(ClaimTypes.Role, roleValue.ToString()!));

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task Login(LoginResponse data)
        {
            // Guardar en SessionStorage
            await _jsSessionStorage.SetValue<string>(ValuesKey.TOKENKEY, data.Token);
            await _jsSessionStorage.SetValue<User>(ValuesKey.USER, data.Users);
            await _jsSessionStorage.SetValue<List<UserType>>(ValuesKey.SUPPLIERS, data.Suppliers);
            await _jsSessionStorage.SetValue<List<UserType>>(ValuesKey.DEALERS, data.Dealers);
            await _jsSessionStorage.SetValue<List<UserModule>>(ValuesKey.MODULES, data.Modules);

            var selectedSupplier = data.Suppliers.FirstOrDefault()?.Id ?? 0;
            var selectedDealer = data.Dealers.FirstOrDefault(d => d.SupplierId == selectedSupplier.ToString())?.Id ?? 0;

            await _jsSessionStorage.SetValue<int>(ValuesKey.SELECTEDSUPPLIER, selectedSupplier);
            await _jsSessionStorage.SetValue<int>(ValuesKey.SELECTEDDEALER, selectedDealer);

            // Actualizar UserSession
            _session.UserId = data.Users.Id;
            _session.SupplierId = selectedSupplier;
            _session.DealerId = selectedDealer;
            _session.UserActive = data.Users;
            _session.UserSuppliers = data.Suppliers;
            _session.UserDealer = data.Dealers;
            _session.UserModules = data.Modules;
            _session.IsFirstTime = false;

            var authState = BuildAuthenticationState(data.Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            _http.DefaultRequestHeaders.Authorization = null;
            await _jsSessionStorage.ClearAll();

            // Resetear UserSession
            _session.UserId = 0;
            _session.SupplierId = 0;
            _session.DealerId = 0;
            _session.UserActive = new User();
            _session.UserSuppliers.Clear();
            _session.UserDealer.Clear();
            _session.UserModules.Clear();
            _session.IsFirstTime = true;

            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var authState = await GetAuthenticationStateAsync();
            return authState.User.Identity!.IsAuthenticated;
        }

        public async Task<List<UserModule>> GetUserRoleAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserModule>>(ValuesKey.MODULES);
            return Check<List<UserModule>>(data);
        }

        public async Task<List<UserType>> GetUserDealerAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserType>>(ValuesKey.DEALERS);
            return Check<List<UserType>>(data);
        }

        public async Task<List<UserType>> GetUserSupplierAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserType>>(ValuesKey.SUPPLIERS);
            return Check<List<UserType>>(data);
        }

        public async Task<User> GetUserAsync()
        {
            var data = await _jsSessionStorage.GetValue<User>(ValuesKey.USER);
            return Check<User>(data);
        }

        public async Task<int> GetSelectedDealerAsync()
        {
            var data = await _jsSessionStorage.GetValue<int>(ValuesKey.SELECTEDDEALER);
            return Check<int>(data);
        }

        public async Task<int> GetSelectedSupplierAsync()
        {
            var data = await _jsSessionStorage.GetValue<int>(ValuesKey.SELECTEDSUPPLIER);
            return Check<int>(data);
        }

        public async Task SetValueSessionStorage<T>(T data, ValuesKey key)
        {
            await _jsSessionStorage.SetValue<T>(key, data);
        }

        public async Task SetTimerInactivo<T>(DotNetObjectReference<T> data) where T : class
        {
            await _jsSessionStorage.SetTimerInactivo<DotNetObjectReference<T>>(data);
        }

        private static T Check<T>(T value) where T : new()
        {
            return value == null ? new T() : value;
        }

        public async Task RefreshStaticVariables()
        {
            _session.IsNewOrEdit = false;

            int selectedDealer = await GetSelectedDealerAsync();
            int selectedSupplier = await GetSelectedSupplierAsync();
            var userActive = await GetUserAsync();

            _session.SupplierId = selectedSupplier;
            _session.DealerId = selectedDealer;
            _session.UserId = userActive.Id;
            _session.IsFirstTime = false;
        }

        public async Task RefresMobileStaticVariables()
        {
            if (_session.UserId == 0)
            {
                var mUser = await GetUserAsync();
                _session.UserId = mUser.Id;
                _session.SupplierId = await GetSelectedSupplierAsync();
            }
        }

        public async Task<bool> GetIsMobile()
        {
          return Check<bool>(await _jsSessionStorage.GetValue<bool>(ValuesKey.ISMOBILE));
        }
    }
}
