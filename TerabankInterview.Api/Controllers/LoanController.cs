using Application.DTOs.Loan;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TerabankInterview.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLoanDto>> GetLoanByIdAsync(Guid id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLoanDto>>> GetAllLoansAsync()
        {
            var loan = await _loanService.GetAllLoansAsync();
            return loan;
        }

        [HttpPost]
        public async Task<ActionResult<AddLoanDto>> AddLoanAsync([FromBody] AddLoanDto loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLoan = await _loanService.AddLoanAsync(loan);

            if (createdLoan == null)
            {
                return BadRequest("Failed to create a loan");
            }

            return CreatedAtAction(nameof(AddLoanAsync).Replace("Async", ""),
                new { createdLoan.Percentage }, createdLoan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLoanAsync([FromBody] UpdateLoanDto loan, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _loanService.UpdateLoanAsync(loan, id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoanAsync(Guid id)
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }
    }
}