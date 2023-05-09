using Accounting.Domain.Customers;
using Accounting.Domain.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class OrderSubmittedHandler : INotificationHandler<OrderSubmitted>
  {

    private readonly IAccountDomainService accountDomainService;
    private readonly IAccountRepository accountRepository;
    private readonly IOrderRepository orderRepository;

    public OrderSubmittedHandler(IAccountDomainService accountDomainService, IAccountRepository accountRepository, IOrderRepository orderRepository)
    {
      this.accountDomainService = accountDomainService;
      this.accountRepository = accountRepository;
      this.orderRepository = orderRepository;
    }

    public async Task Handle(OrderSubmitted notification, CancellationToken cancellationToken)
    {
 

      var account = await accountRepository.FindAsync(x=> x.Id == notification.Account.Id);

      account.WithDraw(new Money(notification.Order.TotalPrice, "TL"), TransferChannel.Online);

      await accountRepository.UpdateAsync(notification.Account);


    }
  }
}
