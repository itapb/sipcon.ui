using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Primitives;
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
    public class AuthenticationProviderJWT(ISessionStorageService jsSessionStorageService, HttpClient httpClient) : AuthenticationStateProvider, IAuthorizeService
    {
       
        private readonly HttpClient _http = httpClient;
        
        private readonly ISessionStorageService _jsSessionStorage = jsSessionStorageService;
        //public static readonly string TokenKey = "TOKENKEY";
        private static AuthenticationState Anonimo => new(new ClaimsPrincipal(new ClaimsIdentity()));
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsSessionStorage.GetValue<string>(ValuesKey.TOKENKEY);
            await Task.CompletedTask;
            
            if (string.IsNullOrEmpty(token))
            {
                return Anonimo;
            }
           

            return BuildAuthenticationState(token);

            //var identity = new ClaimsIdentity();
            //return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
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
            {
                claims.Add(new Claim(ClaimTypes.Role, roleValue.ToString()!));
            }
            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }

        public async Task Login(LoginResponse data)
        {
            await _jsSessionStorage.SetValue<string>(ValuesKey.TOKENKEY, data.Token);
            await _jsSessionStorage.SetValue<User>(ValuesKey.USER, data.Users);
            await _jsSessionStorage.SetValue<List<UserType>>(ValuesKey.SUPPLIERS, data.Suppliers);
            await _jsSessionStorage.SetValue<List<UserType>>(ValuesKey.DEALERS, data.Dealers);
            await _jsSessionStorage.SetValue<List<UserModule>>(ValuesKey.MODULES, data.Modules);
            var selectedDealer = data.Dealers.FirstOrDefault() != null ? data.Dealers.FirstOrDefault()!.Id : 0;
            var selectedSupplier = data.Suppliers.FirstOrDefault() != null ? data.Suppliers.FirstOrDefault()!.Id : 0;
            await _jsSessionStorage.SetValue<int>(ValuesKey.SELECTEDSUPPLIER, selectedSupplier);
            await _jsSessionStorage.SetValue<int>(ValuesKey.SELECTEDDEALER, selectedDealer);

            Useful.userId = data.Users.Id;
            Useful.supplierId = selectedSupplier;
            Useful.dealerId = selectedDealer;

            var authState = BuildAuthenticationState(data.Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            _http.DefaultRequestHeaders.Authorization = null;
            
            await _jsSessionStorage.ClearAll();

            await Task.CompletedTask;
            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var authState = await GetAuthenticationStateAsync();
            var user = authState.User;
            return user.Identity!.IsAuthenticated;
        }

        public async Task<List<UserModule>> GetUserRoleAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserModule>>(ValuesKey.MODULES);
            var modulos = Check<List<UserModule>>(data);
            return modulos;
        }

        public async Task<List<UserType>> GetUserDealerAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserType>>(ValuesKey.DEALERS);
            var dealers = Check<List<UserType>>(data);
            return dealers;
        }

        public async Task<List<UserType>> GetUserSupplierAsync()
        {
            var data = await _jsSessionStorage.GetValue<List<UserType>>(ValuesKey.SUPPLIERS);
            var supplier = Check<List<UserType>>(data);
            return supplier;
        }

        public async Task<User> GetUserAsync()
        {
            var data = await _jsSessionStorage.GetValue<User>(ValuesKey.USER);
            var user = Check<User>(data);
            return user;
        }

        public async Task<int> GetSelectedDealerAsync()
        {
            var data = await _jsSessionStorage.GetValue<int>(ValuesKey.SELECTEDDEALER);
            var Item = Check<int>(data);
            return Item;
        }

        public async Task<int> GetSelectedSupplierAsync()
        {
            var data = await _jsSessionStorage.GetValue<int>(ValuesKey.SELECTEDSUPPLIER);
            var Item = Check<int>(data);
            return Item;
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

    }
}
