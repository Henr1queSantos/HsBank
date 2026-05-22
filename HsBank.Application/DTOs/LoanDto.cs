namespace HsBank.Application.DTOs;

public class LoanDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public DateTime CreatedAt { get; set; }
    
}