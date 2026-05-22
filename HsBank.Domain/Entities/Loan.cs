using HsBank.Domain.Common;
using HsBank.Domain.Enums;

namespace HsBank.Domain.Entities;

public class Loan : Entity
{
    public Guid CustomerId { get; private set; } 
    public decimal Amount { get; private set; } 
    public LoanStatus Status { get; private set; } 

    public Loan(Guid customerId, decimal amount)
    {
        CustomerId = customerId;
        Amount = amount;
        Status = LoanStatus.Pending;
    }

    public void Approve()
    {
        if (Status != LoanStatus.Pending)
        {
            throw new Exception("It's only possible to reject loans that are pending!only approve loans that are currently pending!");
        }

        Status = LoanStatus.Approved;
    }

    public void Reject()
    {
        if (Status != LoanStatus.Pending)
        {
            throw new Exception("It's only possible to reject loans that are pending!");
        }

        Status = LoanStatus.Rejected;
    }
}