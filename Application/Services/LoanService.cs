using Application.DTOs.Loan;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }
        
        public async Task<GetLoanDto> GetLoanByIdAsync(Guid id)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(id);
            return _mapper.Map<GetLoanDto>(loan);
        }

        public async Task<List<GetLoanDto>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return _mapper.Map<List<GetLoanDto>>(loans);
        }

        public async Task<AddLoanDto> AddLoanAsync(AddLoanDto addLoanDto)
        {
            var loanEntity = _mapper.Map<Loan>(addLoanDto);
            var addedLoan = await _loanRepository.AddLoanAsync(loanEntity);
            return _mapper.Map<AddLoanDto>(addedLoan);
        }

        public async Task<UpdateLoanDto> UpdateLoanAsync(UpdateLoanDto updateLoanDto, Guid id)
        {
            var existingLoan = await _loanRepository.GetLoanByIdAsync(id);
            if (existingLoan == null)
            {
                return null;
            }

            var loan = _mapper.Map(updateLoanDto, existingLoan);

            var updatedLoan = await _loanRepository.UpdateLoanAsync(loan);

            return _mapper.Map<UpdateLoanDto>(updatedLoan);
        }

        public async Task DeleteLoanAsync(Guid loanId)
        {
            await _loanRepository.DeleteLoanAsync(loanId);
        }
    }
}