using Accounting.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public class EFAccountRepository : IAccountRepository
  {
    private readonly AccountingContext accountingContext;
    public EFAccountRepository(AccountingContext accountingContext)
    {
      this.accountingContext = accountingContext;
    }

    public async Task CreateAsync(Account item)
    {
      await this.accountingContext.AddAsync(item);
      await this.accountingContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(string Id)
    {
      var entity = await this.accountingContext.Accounts.FindAsync(Id);

      if(entity is not null)
      {
        this.accountingContext.Remove(entity);
        await this.accountingContext.SaveChangesAsync();
      }
    
    }

    public async Task<Account> FindAsync(Expression<Func<Account, bool>> expression)
    {
      return await this.accountingContext.Accounts.FirstOrDefaultAsync(expression);
    }

    public IQueryable Query(Expression<Func<Account, bool>> expression)
    {
      return this.accountingContext.Accounts.Where(expression).AsNoTracking().AsQueryable();
    }

    public async Task UpdateAsync(Account item)
    {
      this.accountingContext.Accounts.Update(item);
      await this.accountingContext.SaveChangesAsync();
    }

    public async Task<List<Account>> WhereAsync(Expression<Func<Account, bool>> expression)
    {
      return await this.accountingContext.Accounts.Where(expression).ToListAsync();
    }
  }
}
