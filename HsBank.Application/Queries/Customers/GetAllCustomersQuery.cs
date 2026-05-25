using HsBank.Application.Wrappers;
using HsBank.Domain.Entities;
using MediatR;

namespace HsBank.Application.Queries.Customers;

public class GetAllCustomersQuery : IRequest<PagedResult<Customer>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetAllCustomersQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}