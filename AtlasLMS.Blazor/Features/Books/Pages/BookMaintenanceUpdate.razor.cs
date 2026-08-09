using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Pages;

public partial class BookMaintenanceUpdate
{
    #region Parameters-------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ICategoryService CategoryService { get; set; }
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private BookDetailDto? bookReadOnly;
    private BookUpdateDto book = new();
    private List<AuthorReadDto> authors = new();
    private List<LocationReadDto> locations = new();
    private List<CategoryReadDto> categories = new();
    private bool currentPost = false;

    #region OnInitialized------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        authors = (await AuthorService.GetAuthorsAsync()).ToList();
        locations = (await LocationService.GetLocationsAsync()).ToList();
        categories = (await CategoryService.GetCategoriesAsync()).ToList();
    }
    #endregion

    #region OnParametersSet----------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        bookReadOnly = await BookService.GetBookDetailAsync(ID);

        if (bookReadOnly is null) return;

        book.Title = bookReadOnly.Title;
        book.Stock = bookReadOnly.Stock;
        book.Synopsis = bookReadOnly.Synopsis;
        book.ISBN = bookReadOnly.ISBN;
        book.PublicationAt = bookReadOnly.PublicationAt;
        book.AuthorID = bookReadOnly.AuthorID;
        book.CategoryID = bookReadOnly.CategoryID;
        book.LocationID = bookReadOnly.LocationID;
    }
    #endregion

    #region Actions------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/books");
    private async Task HandleSaveBook(BookUpdateDto dto)
    {
        currentPost = true;

        var response = await BookService.UpdateBookAsync(ID, dto);

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Libro actualizado correctamente."));
            NavigationService.NavigateTo("/books");
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
