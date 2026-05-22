using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using HsBank.Infrastructure.Persistence;

namespace HsBank.Infrastructure.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly HsBankDbContext _context;

    public LoanRepository(HsBankDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Loan loan, CancellationToken cancellationToken)
    {
        await _context.Loans.AddAsync(loan, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}