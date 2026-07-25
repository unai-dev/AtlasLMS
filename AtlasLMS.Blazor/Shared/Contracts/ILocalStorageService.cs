namespace AtlasLMS.Blazor.Shared.Contracts
{
    public interface ILocalStorageService
    {
        Task GetItemAsync(string key);
        Task SetItemAsync(string key, string value);
    }
}