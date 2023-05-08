using Accounting.Console.Data.Configurations;
using Accounting.Domain.Accounts;
using Accounting.Domain.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public class AccountingContext:DbContext
  {
    private readonly IMediator mediator;

    public AccountingContext(IMediator mediator)
    {
      this.mediator = mediator;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }

    


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      await this.mediator.DispatchDomainEventsAsync(this);

      return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AccountConfiguration());
      modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
      modelBuilder.ApplyConfiguration(new CustomerConfiguration());
      

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=AccountingDb;Trusted_Connection=True;MultipleActiveResultSets=True");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
