using AtlasLMS.Blazor.Shared.Contracts;
using AtlasLMS.Tools;

using Microsoft.JSInterop;

namespace AtlasLMS.Blazor.Shared.Services;


public class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime _jS;

    public LocalStorageService(IJSRuntime jS)
    {
        _jS = jS;
    }

    public async Task GetItemAsync(string key)
    {
        key = AtlasHelper.NormalizeUpper(key);
        await _jS.InvokeVoidAsync("localStorage.getItem", key);
    }

    public async Task SetItemAsync(string key, string value)
    {
        key = AtlasHelper.NormalizeUpper(key);
        await _jS.InvokeVoidAsync("localStorage.setItem", key, value);
    }
}
