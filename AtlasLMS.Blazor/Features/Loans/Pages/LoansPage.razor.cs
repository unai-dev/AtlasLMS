using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Pages;

public partial class LoansPage
{
    [Inject] public required ILoanService LoanService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<LoanReadDto> loans = new List<LoanReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshLoans();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private void HandleAddLoan() => NavigationService.NavigateTo("/loans/create");
    private void HandleViewLoan(int ID) => NavigationService.NavigateTo($"/loans/{ID}");
    private async Task HandleDeleteLoan(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await LoanService.DeleteLoanAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Prestamo eliminado con exito"));
                await RefreshLoans();
                return;
            }

            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshLoans()
    {
        isLoading = true;
        loans = (await LoanService.GetLoansAsync()).ToList();
        if (loans.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay prestamos disponibles"));
            return;
        }
        isLoading = false;
    }
    #endregion
}
