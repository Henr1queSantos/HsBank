using MediatR;

namespace HsBank.Application.Commands.Customers;

public class CreateCustomerCommand : IRequest<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}