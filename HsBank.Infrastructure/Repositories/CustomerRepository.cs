using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using HsBank.Infrastructure.Persistence;

namespace HsBank.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly HsBankDbContext _context;

    public CustomerRepository(HsBankDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _context.Customers.AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}