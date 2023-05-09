using Accounting.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public class EFCustomerRepository : ICustomerRepository
  {
    private readonly AppDbContext accountingContext;

    public EFCustomerRepository(AppDbContext accountingContext)
    {
      this.accountingContext = accountingContext;
    }

    public Task CreateAsync(Customer item)
    {
      throw new NotImplementedException();
    }

    public Task DeleteAsync(string Id)
    {
      throw new NotImplementedException();
    }

    public Task<Customer> FindAsync(Expression<Func<Customer, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public async Task<Customer> FindCustomerWithAccountsAsync(string Id)
    {
      var cus = await this.accountingContext.Customers.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == Id);

      if (cus is null)
        throw new Exception("no customer was found");

      return cus;

     ;
    }

    public IQueryable Query(Expression<Func<Customer, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public Task<IQueryable<Customer>> QueryAsync(Expression<Func<Customer, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
      await accountingContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Customer item)
    {
      throw new NotImplementedException();
    }

    public Task<List<Customer>> WhereAsync(Expression<Func<Customer, bool>> expression)
    {
      throw new NotImplementedException();
    }
  }
}
