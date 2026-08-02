using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Pages;

public partial class LoansPage
{
    [Inject] public required ILoanService LoanService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

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

            await SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshLoans()
    {
        isLoading = true;
        loans = (await LoanService.GetLoansAsync()).ToList();
        isLoading = false;
        if (loans.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay prestamos disponibles"));
            return;
        }
    }

    private async Task SwitchExceptionMessage(HttpResponseMessage response)
    {

        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.InternalServerError:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
