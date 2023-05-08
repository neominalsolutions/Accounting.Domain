using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class AccountTransaction:Entity<string>
  {
    public string Id { get; init; }
    public Money Money { get; init; }
    public AccountTransactionType Type { get; init; }
    public DateTime CreatedAt { get; init; }

    public Account Account { get; set; }
    public string AccountId { get; set; }



    public AccountTransaction()
    {

    }

    public AccountTransaction(string accountId, Money money, AccountTransactionType type)
    {
      Id = Guid.NewGuid().ToString();
      AccountId = accountId;
      Money = money;
      Type = type;
      CreatedAt = DateTime.Now;
    }
  }
}
