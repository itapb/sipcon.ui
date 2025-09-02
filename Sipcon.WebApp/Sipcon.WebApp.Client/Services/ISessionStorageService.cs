
using Sipcon.WebApp.Client.Enum;

namespace Sipcon.WebApp.Client.Services
{
    public interface ISessionStorageService
    {
        Task<T> GetValue<T>(ValuesKey key);

        Task SetValue<T>(ValuesKey key,  T value);

        Task RemoveValue(ValuesKey key);

        Task ClearAll();

    }
}
