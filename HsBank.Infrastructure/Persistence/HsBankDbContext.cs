using HsBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HsBank.Infrastructure.Persistence;

public class HsBankDbContext : DbContext
{
    public HsBankDbContext(DbContextOptions<HsBankDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Document)
            .HasMaxLength(14);
            
        modelBuilder.Entity<Loan>()
            .Property(l => l.Amount)
            .HasColumnType("decimal(18,2)");
    }
}