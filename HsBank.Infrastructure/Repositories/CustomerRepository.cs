using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using HsBank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<(IEnumerable<Customer> Customers, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Customers.CountAsync(cancellationToken);

        var customers = await _context.Customers
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize)                   
            .ToListAsync(cancellationToken);

        return (customers, totalCount);
    }

    public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }
}