using HsBank.Application.Interfaces.Authentication;
using HsBank.Domain.Repositories;
using MediatR;

namespace HsBank.Application.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(ICustomerRepository customerRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _customerRepository = customerRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByEmailAsync(request.Email, cancellationToken);
        
        if (customer is null)
            throw new Exception("Invalid credentials"); 

        if (!_passwordHasher.Verify(request.Password, customer.PasswordHash))
            throw new Exception("Invalid credentials");

        return _jwtTokenGenerator.GenerateToken(customer.Id, customer.FullName, customer.Role);
    }
}