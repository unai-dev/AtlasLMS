using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Loans.Components;

public partial class LoanItem
{
    #region Parameters------------------------------------------------------------------
    [Parameter, EditorRequired] public LoanReadDto Loan { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    #endregion
}
