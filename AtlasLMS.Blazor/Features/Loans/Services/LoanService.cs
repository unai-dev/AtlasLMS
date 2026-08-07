using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Loans.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
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

    public async Task<LoanDetailDto?> GetLoanAsync(int ID) =>
        await _http.GetFromJsonAsync<LoanDetailDto>($"loans/detail/{ID}");

    public async Task<HttpResponseMessage> CreateLoanAsync(LoanCreateDto dto) =>
        await _http.PostAsJsonAsync("loans", dto);

    public async Task<HttpResponseMessage> DeleteLoanAsync(int ID) =>
        await _http.DeleteAsync($"loans/{ID}");
}
