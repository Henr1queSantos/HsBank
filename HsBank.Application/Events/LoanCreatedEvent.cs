namespace HsBank.Application.Events;

public class LoanCreatedEvent
{
    public Guid LoanId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}