using HsBank.Application.Interfaces.Authentication;
using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Commands.Customers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPasswordHasher _passwordHasher;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IPasswordHasher passwordHasher)
    {
        _customerRepository = customerRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _passwordHasher.Hash(request.Password);
        var customer = new Customer(request.FullName, request.Document, request.Email, hashedPassword);
        
        await _customerRepository.AddAsync(customer, cancellationToken);

        return customer.Id;
    }
}