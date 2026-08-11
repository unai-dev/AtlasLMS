using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorPage
{
    #region Paramaters-----------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private AuthorDetailDto? author;
    private bool isLoading = false;

    #region OnParametersSet--------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        author = await AuthorService.GetAuthorDetailAsync(ID);
        if (author is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions----------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/authors");
    //Provisional
    private void HandleBooks() => NavigationService.NavigateTo("/books");
    #endregion
}
