using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Commands.Customers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;

    // We inject the Interface, completely decoupling this class from Entity Framework!
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var newCustomer = new Customer(request.FullName, request.Document, request.Email);

        await _customerRepository.AddAsync(newCustomer, cancellationToken);

        return newCustomer.Id;
    }
}