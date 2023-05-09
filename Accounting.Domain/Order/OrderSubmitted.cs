using Accounting.Domain.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class OrderSubmitted: INotification
  {
    public Order Order { get; private set; }
    public Account Account { get; private set; }

  
    public OrderSubmitted(Order order, Account account)
    {
      this.Order = order;
      this.Account = account;
    }
  }
}
