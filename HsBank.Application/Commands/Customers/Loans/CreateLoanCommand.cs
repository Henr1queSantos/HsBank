using MediatR;

namespace HsBank.Application.Commands.Loans;

public class CreateLoanCommand : IRequest<Guid>
{
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
}