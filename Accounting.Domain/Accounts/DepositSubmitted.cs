using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class DepositSubmitted:INotification
  {
    public string AccountId { get; init; }
    public string CustomerId { get; init; }
    public Money Money { get; init; }

    public TransferChannel TransferChannel { get; init; }

 

    public DepositSubmitted(string accountId, string customerId, Money money, TransferChannel transferChannel)
    {
      AccountId = accountId;
      CustomerId = customerId;
      Money = money;
      TransferChannel = transferChannel;
    }
  }
}
