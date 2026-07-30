using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Loans.Contracts
{
    public interface ILoanService
    {
        Task<HttpResponseMessage> DeleteLoanAsync(int ID);
        Task<IEnumerable<LoanReadDto>> GetLoansAsync();
    }
}