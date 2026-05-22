using HsBank.Domain.Common;

namespace HsBank.Domain.Entities;

public class Customer : Entity
{
    public string FullName { get; private set; }
    public string Document { get; private set; } 
    public string Email { get; private set; }

    public Customer(string fullName, string document, string email)
    {
        FullName = fullName;
        Document = document;
        Email = email;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }
}