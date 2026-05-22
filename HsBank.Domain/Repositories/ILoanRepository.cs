using HsBank.Domain.Entities;

namespace HsBank.Domain.Repositories;

public interface ILoanRepository
{
    Task AddAsync(Loan loan, CancellationToken cancellationToken);
    Task<IEnumerable<Loan>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
}