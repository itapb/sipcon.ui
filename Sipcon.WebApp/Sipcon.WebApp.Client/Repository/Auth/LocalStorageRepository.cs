using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Sipcon.WebApp.Client.Enum;
using Sipcon.WebApp.Client.Models;
using Sipcon.WebApp.Client.Services;
using System.Text.Json;
using static MudBlazor.Colors;

namespace Sipcon.WebApp.Client.Repository.Auth
{
    public class LocalStorageRepository(IJSRuntime jsRuntime) : ILocalStorageService
    {
        private readonly IJSRuntime _js = jsRuntime;
        private readonly string _tipoAlmacenamiento = "localStorage.";

        public async Task<T> GetValue<T>(ValuesKey key)
        {
            string data = await _js.InvokeAsync<string>($"{_tipoAlmacenamiento}getItem", key.ToString()).ConfigureAwait(false);
            await Task.CompletedTask;
            var setData = data == null ? default : JsonSerializer.Deserialize<T>(data);
            return setData;
        }

        public async Task SetValue<T>(ValuesKey key, T value)
        {
            await _js.InvokeVoidAsync($"{_tipoAlmacenamiento}setItem", key.ToString(), JsonSerializer.Serialize(value).ToString()).ConfigureAwait(false);
        }

        public async Task RemoveValue(ValuesKey key)
        {
            await _js.InvokeVoidAsync($"{_tipoAlmacenamiento}removeItem", key.ToString()).ConfigureAwait(false);
        }

        public async Task ClearAll()
        {
            await _js.InvokeVoidAsync($"{_tipoAlmacenamiento}clear").ConfigureAwait(false);
        }

        public async Task SetTimerInactivo<T>(T value)
        {
            await _js.InvokeVoidAsync($"timerInactivo", value).ConfigureAwait(false);
        }
    }
}
