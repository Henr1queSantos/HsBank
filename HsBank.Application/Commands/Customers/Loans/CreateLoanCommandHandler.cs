using HsBank.Application.Events;
using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using MassTransit;
using MediatR;

namespace HsBank.Application.Commands.Loans;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateLoanCommandHandler(ILoanRepository loanRepository, IPublishEndpoint publishEndpoint)
    {
        _loanRepository = loanRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan(request.CustomerId, request.Amount, request.TermInMonths);

        await _loanRepository.AddAsync(loan, cancellationToken);

        await _publishEndpoint.Publish(new LoanCreatedEvent
        {
            LoanId = loan.Id,
            CustomerId = request.CustomerId,
            Amount = request.Amount,
            CreatedAt = loan.CreatedAt
        }, cancellationToken);

        return loan.Id;
    }
}