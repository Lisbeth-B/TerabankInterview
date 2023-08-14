namespace Application.DTOs.Loan
{
    public class GetLoanDto
    {
        public Guid Id { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
    }
}