using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class AccountTransactionType: Enumeration
  {
    public static AccountTransactionType Deposit = new(100, nameof(Deposit));
    public static AccountTransactionType Withdraw = new(200, nameof(Withdraw));

    public AccountTransactionType(int id, string name)
        : base(id, name)
    {
    }
  }

  
}
