using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Customers
{
  public interface ICustomerRepository:IRepository<Customer>
  {
    Task<Customer> FindCustomerWithAccountsAsync(string Id);
  }
}
