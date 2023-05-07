using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.SeedWork
{
  public abstract class Entity<TKey> where TKey:IComparable
  {
    public TKey Id { get; set; }
  }
}
