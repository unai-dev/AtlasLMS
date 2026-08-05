using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Pages;

public partial class LoanMaintenanceCreate
{
    [Inject] public required ILoanService LoanService { get; set; }
    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private LoanCreateDto loan = new();
    private List<BookReadDto> books = new();
    private List<UserReadDto> users = new();
    private bool currentPost = false;

    #region OnInitialized---------------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        books = (await BookService.GetBooksAsync()).ToList();
        users = (await UserService.GetUsersAsync()).ToList();
    }
    #endregion

    #region Actions------------------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/loans");
    private void WhenChangeBook() => Console.WriteLine($"Libro selecionado: {loan.BookID}");
    private async Task HandleSaveLoan(LoanCreateDto loan)
    {
        currentPost = true;
        var response = await LoanService.CreateLoanAsync(loan);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Prestamo creado correctamente"));
            NavigationService.NavigateTo("/loans");
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);

        currentPost = false;
    }
    #endregion
}
