using HsBank.Domain.Entities;
using MediatR;

namespace HsBank.Application.Queries.Customers;

public class GetAllCustomersQuery : IRequest<List<Customer>>
{
}