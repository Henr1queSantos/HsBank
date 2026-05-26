using MediatR;

namespace HsBank.Application.Commands.Auth;

public class LoginCommand : IRequest<string>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}