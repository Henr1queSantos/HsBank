using HsBank.Application.DTOs;
using MediatR;

namespace HsBank.Application.Queries.Loans;

public class GetLoansByCustomerQuery : IRequest<List<LoanDto>>
{
    public Guid CustomerId { get; set; }

    public GetLoansByCustomerQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}