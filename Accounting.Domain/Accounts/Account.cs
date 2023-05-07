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
    public Account(string id, string accountNumber, string iBAN, string customerId)
    {
      Id = id;
      AccountNumber = accountNumber;
      IBAN = iBAN;
      CustomerId = customerId;
    }

    public string Id { get; init; }
    public string AccountNumber { get; private set; }

    public string IBAN { get; private set; }

    public string CustomerId { get; private set; }

    public Money Balance { get; private set; }

    public bool IsBlocked { get; private set; }

    public string? BlockReason { get; private set; }

    public Money AdvanceAccountLimit { get; private set; }


    private List<AccountTransaction> _transactions = new();
    public IReadOnlyCollection<AccountTransaction> Transactions => _transactions.AsReadOnly();


    public void SetBalance(Money balance)
    {
      Balance = balance;
    }

    public void Deposit(Money money, TransferChannel transferChannel)
    {
      // DomainEvent

      var @event = new DepositSubmitted(Id, CustomerId, money, transferChannel);
      AddDomainEvent(@event);

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.Deposit));
    }

    public void WithDraw(Money money, TransferChannel transferChannel)
    {
      // DomainEvent

      var @event = new WithDrawSubmitted(Id, CustomerId, money, transferChannel);
      AddDomainEvent(@event);

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.Withdraw));
    }

    public void Block(string reason)
    {
      BlockReason = reason;
      IsBlocked = true;
    }


   


  }
}
