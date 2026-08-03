using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

namespace AtlasLMS.Blazor.Security.Services;

public class AtlasExceptionHandler : IAtlasExceptionHandler
{
    private readonly ToastService _toastService;

    public AtlasExceptionHandler(ToastService toastService)
    {
        _toastService = toastService;
    }

    public async Task SwitchExceptionMessage(HttpResponseMessage response)
    {
        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;

        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
            case HttpStatusCode.BadRequest:
                _toastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
}
