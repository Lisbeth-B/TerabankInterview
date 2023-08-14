using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanByIdAsync(Guid id);
        Task<List<Loan>> GetAllLoansAsync();
        Task<Loan> AddLoanAsync(Loan loan);
        Task<Loan> UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(Guid loanId);
    }
}