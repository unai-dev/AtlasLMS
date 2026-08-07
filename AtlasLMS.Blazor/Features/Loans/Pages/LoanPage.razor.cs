using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Pages;

public partial class LoanPage
{
    #region Paramaters-----------------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required ILoanService LoanService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private LoanDetailDto? loan;
    private bool isLoading = false;

    #region OnParametersSet------------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        loan = await LoanService.GetLoanAsync(ID);
        if (loan is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions---------------------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/loans");
    private void HandleViewUser(string userID) => NavigationService.NavigateTo($"/users/{userID}");
    #endregion
}
