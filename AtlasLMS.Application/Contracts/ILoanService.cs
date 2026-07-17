using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface ILoanService
{
    Task<LoanReadDto> CreateLoanAsync(LoanCreateDto dto);
    Task DeleteLoanAsync(int ID);
    Task<LoanReadDto> GetLoanAsync(int ID);
    Task<LoanReadDto> GetLoanByBookAsync(int bookID);
    Task<IEnumerable<LoanReadDto>> GetLoansAsync();
    Task<IEnumerable<LoanReadDto>> GetLoansByDueDateAsync(DateTime? limitDueDate);
    Task<IEnumerable<LoanReadDto>> GetLoansByUserAsync(string userID);
}