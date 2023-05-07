using Accounting.Domain.Customers;
using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public interface IAccountDomainService:IDomainService
  {
    void Deposit(Account acc,Money money,TransferChannel channel);
    void Withdraw(Account acc,Money money, TransferChannel channel);
  }
}
