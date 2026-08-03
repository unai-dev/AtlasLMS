using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Pages;

public partial class LoanMaintenanceCreate
{
    [Inject] public required ILoanService LoanService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private LoanCreateDto loan = new();
    private bool currentPost = false;

    #region Actions------------------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/loans");
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
