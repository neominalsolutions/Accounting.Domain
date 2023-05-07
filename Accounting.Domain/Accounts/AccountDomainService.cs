using Accounting.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  /// <summary>
  /// Bussiness Rules
  /// </summary>
  public class AccountDomainService : IAccountDomainService
  {
   

    /// <summary>
    /// Hesap blokeli ise para yatıralamaz
    /// Hafta sonları maksimum para transfer limiti 5000 TL'dir
    /// </summary>
    /// <param name="acc"></param>
    /// <param name="cus"></param>
    /// <param name="money"></param>
    /// <param name="channel"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Deposit(Account acc, Money money, TransferChannel channel)
    {
      var today = DateTime.Now;

      if (acc.IsBlocked)
      {
        throw new AccountBlocked();
      }

      if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
      {
        if (money > new Money(5000, "TL"))
        {
          throw new TransferLimitException(5000, channel.Name.ToString());
        }
      }

      acc.SetBalance(acc.Balance + money);
    }


    /// <summary>
    ///  Para yatırma işleminde Hesap blokeli ise para çekilemez
    ///  ATM den 5000 TL üzeri para çekilemez
    ///  Online Bankacılık ile 100000 TL üzeri para çekilemez
    ///  Hesap Bakiyesi Avans hesap limitinn altına düşemez
    /// </summary>
    /// <param name="acc"></param>
    /// <param name="money"></param>
    /// <param name="channel"></param>
    /// <exception cref="AdvanceBalanceInsufficent"></exception>
    /// <exception cref="AccountBlocked"></exception>
    /// <exception cref="TransferLimitException"></exception>
    public void Withdraw(Account acc, Money money, TransferChannel channel)
    {


      if (acc.IsBlocked)
      {
        throw new AccountBlocked();
      }

      if (channel == TransferChannel.ATM && money > new Money(5000,money.Currency))
      {
        throw new TransferLimitException(5000, TransferChannel.ATM.ToString());
      }
      else if(channel == TransferChannel.Online && money > new Money(100000, money.Currency))
      {
        throw new TransferLimitException(100000, TransferChannel.Online.ToString());
      }

      if(acc.Balance < money)
      {
        if (money > acc.AdvanceAccountLimit)
        {
          throw new AdvanceBalanceInsufficent();
        }
      }

      acc.SetBalance(acc.Balance - money);

    }
  }
}
