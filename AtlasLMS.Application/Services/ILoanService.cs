using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;

namespace AtlasLMS.Application.Services;

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