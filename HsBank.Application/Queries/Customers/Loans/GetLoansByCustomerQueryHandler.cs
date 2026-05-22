using HsBank.Application.DTOs;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Queries.Loans;

public class GetLoansByCustomerQueryHandler : IRequestHandler<GetLoansByCustomerQuery, List<LoanDto>>
{
    private readonly ILoanRepository _loanRepository;

    public GetLoansByCustomerQueryHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<List<LoanDto>> Handle(GetLoansByCustomerQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetByCustomerIdAsync(request.CustomerId, cancellationToken);

        var loanDtos = loans.Select(loan => new LoanDto
        {
            Id = loan.Id,
            Amount = loan.Amount,
            TermInMonths = loan.TermInMonths,
            CreatedAt = loan.CreatedAt
        }).ToList();

        return loanDtos;
    }
}