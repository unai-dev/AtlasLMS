namespace AtlasLMS.Blazor.Security.Contracts
{
    public interface IAtlasExceptionHandler
    {
        Task SwitchExceptionMessage(HttpResponseMessage response);
    }
}