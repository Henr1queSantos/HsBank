namespace HsBank.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string fullName, string role);
}