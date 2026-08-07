using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorMaintenanceUpdate
{
    #region Paramaters---------------------------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private AuthorUpdateDto author = new();
    private AuthorReadDto? authorReadOnly;
    private bool currentPost = false;

    #region OnParametersSet-----------------------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        authorReadOnly = await AuthorService.GetAuthorAsync(ID);
        if (authorReadOnly is null) return;

        author = new AuthorUpdateDto
        {
            FirstName = authorReadOnly.FirstName,
            LastName = authorReadOnly.LastName,
        };
    }
    #endregion

    #region Actions-------------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/authors");
    private async Task HandleSaveAuthor(AuthorUpdateDto dto)
    {
        currentPost = true;
        var response = await AuthorService.UpdateAuthorAsync(ID, dto);

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Autor actualizado correctamente."));
            NavigationService.NavigateTo("/authors");
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
