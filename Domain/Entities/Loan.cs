namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
    }
}