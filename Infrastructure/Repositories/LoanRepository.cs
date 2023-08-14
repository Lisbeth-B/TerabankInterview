using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly TeraDbContext _context;

        public LoanRepository(TeraDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> GetLoanByIdAsync(Guid id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> AddLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> UpdateLoanAsync(Loan loan)
        {
            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task DeleteLoanAsync(Guid loanId)
        {
            var loan = await GetLoanByIdAsync(loanId);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}