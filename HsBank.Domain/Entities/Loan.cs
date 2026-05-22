namespace HsBank.Domain.Entities;

public class Loan
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; } 
    public decimal Amount { get; private set; }
    public int TermInMonths { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Loan() { }

    public Loan(Guid customerId, decimal amount, int termInMonths)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Amount = amount;
        TermInMonths = termInMonths;
        CreatedAt = DateTime.UtcNow;
    }
}