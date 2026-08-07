using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Pages;

public partial class BookPage
{
    #region Parameters------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private BookDetailDto? book;
    private bool isLoading = false;

    #region OnParametersSet-------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        book = await BookService.GetBookAsync(ID);
        if (book is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions---------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/books");
    private void HandleViewAuthor(int authorID) => NavigationService.NavigateTo($"/authors/{authorID}");
    private void HandleViewLocation(int locationID) => NavigationService.NavigateTo($"/locations/{locationID}");
    #endregion
}
