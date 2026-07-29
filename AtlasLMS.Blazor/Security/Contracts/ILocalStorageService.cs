namespace AtlasLMS.Blazor.Security.Contracts
{
    public interface ILocalStorageService
    {
        Task<string?> GetItemAsync(string key);
        Task SetItemAsync(string key, string value);
    }
}