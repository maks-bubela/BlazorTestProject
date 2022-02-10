using System.Text.Json;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using Microsoft.JSInterop;

namespace BlazorTestProject.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        #region Const
        private const string GetItemConst = "localStorage.getItem";
        private const string SetItemConst = "localStorage.setItem";
        private const string RemoveItemStorage = "localStorage.removeItem";
        #endregion
        private IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>(GetItemConst, key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItem<T>(string key, T value)
        {
            await _jsRuntime.InvokeVoidAsync(SetItemConst, key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync(RemoveItemStorage, key);
        }
    }
}