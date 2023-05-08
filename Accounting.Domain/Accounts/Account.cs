using Accounting.Domain.Customers;
using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class Account:AggregateRoot
  {
    public Account()
    {

    }

    public Account(string accountNumber, string iBAN, string customerId)
    {
      Id = Guid.NewGuid().ToString();
      AccountNumber = accountNumber;
      IBAN = iBAN;
      CustomerId = customerId;
      AdvanceAccountLimit = new Money(1000, "TL");
      Balance = new Money(0, "TL");
    }

    public string Id { get; init; }
    public string AccountNumber { get; private set; }

    public string IBAN { get; private set; }

    public string CustomerId { get; private set; }

    public Customer Customer { get; set; }

    public Money Balance { get; private set; }

    public bool IsBlocked { get; private set; }

    public string? BlockReason { get; private set; }

    public Money AdvanceAccountLimit { get; private set; }


    private List<AccountTransaction> _transactions = new();
    public IReadOnlyCollection<AccountTransaction> Transactions => _transactions.AsReadOnly();



    // double Dispatch
    public void Deposit(Money money, TransferChannel transferChannel, IAccountDomainService accountDomainService)
    {
      // DomainEvent

      Balance += money;

      accountDomainService.Deposit(this, money, transferChannel);

      //var @event = new DepositSubmitted(Id, CustomerId, money, transferChannel);
      //AddDomainEvent(@event);

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.Deposit));
    }

    public void Deposit(Money money, TransferChannel transferChannel)
    {
      // DomainEvent

      Balance+= money;

      var @event = new DepositSubmitted(Id, CustomerId, money, transferChannel);
      AddDomainEvent(@event);

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.Deposit));
    }

    public void WithDraw(Money money, TransferChannel transferChannel)
    {
      // DomainEvent

      Balance -= money;

      var @event = new WithDrawSubmitted(Id, CustomerId, money, transferChannel);
      AddDomainEvent(@event);

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.Withdraw));
    }

    public void Block(string reason)
    {
      BlockReason = reason;
      IsBlocked = true;
    }


    public void UpdateAdvanceLimit(Money money)
    {
      AdvanceAccountLimit = money;
    }

   


  }
}
