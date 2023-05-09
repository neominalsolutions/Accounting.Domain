using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.SeedWork
{
  public interface IRepository<T> where T:AggregateRoot
  {
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(string Id);

    Task SaveChangesAsync();

   IQueryable Query(Expression<Func<T, bool>> expression);
    Task<List<T>> WhereAsync(Expression<Func<T,bool>> expression);
    Task<T> FindAsync(Expression<Func<T, bool>> expression);
  }
}
