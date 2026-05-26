namespace HsBank.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Document { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    
    public string PasswordHash { get; private set; } = string.Empty;
    public string Role { get; private set; } = "User"; 

    public DateTime CreatedAt { get; private set; }

    protected Customer() { }

    public Customer(string fullName, string document, string email, string passwordHash, string role = "User")
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Document = document;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        CreatedAt = DateTime.UtcNow;
    }
}