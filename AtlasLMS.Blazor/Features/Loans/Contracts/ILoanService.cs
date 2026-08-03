using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Loans.Contracts
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanReadDto>> GetLoansAsync();
        Task<HttpResponseMessage> CreateLoanAsync(LoanCreateDto dto);
        Task<HttpResponseMessage> DeleteLoanAsync(int ID);
    }
}