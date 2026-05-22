using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Commands.Loans;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
{
    private readonly ILoanRepository _loanRepository;

    public CreateLoanCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan(request.CustomerId, request.Amount, request.TermInMonths);

        await _loanRepository.AddAsync(loan, cancellationToken);

        return loan.Id;
    }
}