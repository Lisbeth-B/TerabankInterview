using Application.DTOs.Loan;

namespace Application.Interfaces.Services
{
    public interface ILoanService
    {
        Task<GetLoanDto> GetLoanByIdAsync(Guid id);
        Task<List<GetLoanDto>> GetAllLoansAsync();
        Task<AddLoanDto> AddLoanAsync(AddLoanDto addLoanDto);
        Task<UpdateLoanDto> UpdateLoanAsync(UpdateLoanDto loan, Guid id);
        Task DeleteLoanAsync(Guid loanId);
    }
}