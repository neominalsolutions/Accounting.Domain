using Accounting.Console.Data.Configurations;
using Accounting.Domain.Accounts;
using Accounting.Domain.Customers;
using Accounting.Domain.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public class AppDbContext:DbContext
  {
    private readonly IMediator mediator;

    public AppDbContext(IMediator mediator)
    {
      this.mediator = mediator;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }





    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      await this.mediator.DispatchDomainEventsAsync(this);

      var result = await base.SaveChangesAsync(cancellationToken);

      return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AccountConfiguration());
      modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
      modelBuilder.ApplyConfiguration(new CustomerConfiguration());
      modelBuilder.ApplyConfiguration(new OrderConfiguration());
      modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
      

      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=DDDDb;Trusted_Connection=True;MultipleActiveResultSets=True");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
