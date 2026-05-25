using HsBank.Application.Wrappers;
using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Queries.Customers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResult<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PagedResult<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var (customers, totalCount) = await _customerRepository.GetAllPagedAsync(request.PageNumber, request.PageSize, cancellationToken);

        return new PagedResult<Customer>(customers.ToList(), totalCount, request.PageNumber, request.PageSize);
    }
}