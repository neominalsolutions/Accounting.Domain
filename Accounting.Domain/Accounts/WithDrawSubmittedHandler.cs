using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class WithDrawSubmittedHandler : INotificationHandler<WithDrawSubmitted>
  {

    private readonly IAccountDomainService accountDomainService;
    private readonly IAccountRepository accountRepository;

    public WithDrawSubmittedHandler(IAccountDomainService accountDomainService, IAccountRepository accountRepository)
    {
      this.accountDomainService = accountDomainService;
      this.accountRepository = accountRepository;
    }

    public async Task Handle(WithDrawSubmitted notification, CancellationToken cancellationToken)
    {
      var acc = await this.accountRepository.FindAsync(x => x.Id == notification.AccountId);

      accountDomainService.Withdraw(acc, notification.Money, notification.TransferChannel);
    }
  }
}
