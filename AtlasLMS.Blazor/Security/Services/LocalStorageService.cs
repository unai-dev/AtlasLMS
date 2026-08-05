using AtlasLMS.Blazor.Security.Contracts;

using Microsoft.JSInterop;

namespace AtlasLMS.Blazor.Security.Services;


public class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime _jS;

    public LocalStorageService(IJSRuntime jS)
    {
        _jS = jS;
    }

    public async Task<string?> GetItemAsync(string key)
    {
        key = key.ToUpper().Trim();
        return await _jS.InvokeAsync<string?>("localStorage.getItem", key);
    }

    public async Task SetItemAsync(string key, string value)
    {
        key = key.ToUpper().Trim();
        await _jS.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task RemoveItemAsync(string key)
    {
        key = key.ToUpper().Trim();
        await _jS.InvokeVoidAsync("localStorage.removeItem", key);
    }
}
