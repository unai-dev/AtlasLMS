using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Loans.Services;

public class LoanService : ILoanService
{
    private readonly HttpClient _http;

    public LoanService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<LoanReadDto>> GetLoansAsync() =>
    await _http.GetFromJsonAsync<IEnumerable<LoanReadDto>>("loans") ?? [];

    public async Task<HttpResponseMessage> DeleteLoanAsync(int ID) =>
        await _http.DeleteAsync($"loans/{ID}");
}
