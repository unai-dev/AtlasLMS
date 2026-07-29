using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Tools;

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
        key = AtlasHelper.NormalizeUpper(key);
        return await _jS.InvokeAsync<string?>("localStorage.getItem", key);
    }

    public async Task SetItemAsync(string key, string value)
    {
        key = AtlasHelper.NormalizeUpper(key);
        await _jS.InvokeVoidAsync("localStorage.setItem", key, value);
    }
}
