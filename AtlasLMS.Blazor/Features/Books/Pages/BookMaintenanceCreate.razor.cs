using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Pages;

public partial class BookMaintenanceCreate
{
    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ICategoryService CategoryService { get; set; }
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private BookCreateDto book = new();
    private List<AuthorReadDto> authors = new();
    private List<CategoryReadDto> categories = new();
    private List<LocationReadDto> locations = new();
    private bool currentPost = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        authors = (await AuthorService.GetAuthorsAsync()).ToList();
        categories = (await CategoryService.GetCategoriesAsync()).ToList();
        locations = (await LocationService.GetLocationsAsync()).ToList();
    }
    #endregion

    #region Actions-----------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/books");
    private async Task HandleSaveBook(BookCreateDto book)
    {
        currentPost = true;
        var response = await BookService.CreateBookAsync(book);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Libro creado correctamente."));
            NavigationService.NavigateTo("/books");
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
