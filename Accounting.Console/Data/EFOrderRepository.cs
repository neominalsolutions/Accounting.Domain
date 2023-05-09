using Accounting.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public class EFOrderRepository : IOrderRepository
  {
    private readonly AppDbContext db;

    public EFOrderRepository(AppDbContext db)
    {
      this.db = db;
    }



    public async Task CreateAsync(Order item)
    {
      await db.Orders.AddAsync(item);
      await db.SaveChangesAsync();
    }

    public Task DeleteAsync(string Id)
    {
      throw new NotImplementedException();
    }

    public async Task<Order> FindAsync(Expression<Func<Order, bool>> expression)
    {
      return await db.Orders.FindAsync(expression);
    }

    public IQueryable Query(Expression<Func<Order, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
      await db.SaveChangesAsync();
    }

    public Task UpdateAsync(Order item)
    {
      throw new NotImplementedException();
    }

    public Task<List<Order>> WhereAsync(Expression<Func<Order, bool>> expression)
    {
      throw new NotImplementedException();
    }
  }
}
