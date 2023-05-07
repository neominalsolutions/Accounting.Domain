using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class Money : ValueObject
  {
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(decimal amount,string currency)
    {
      ArgumentNullException.ThrowIfNull(amount);
      ArgumentNullException.ThrowIfNull(currency);

      Amount = amount;
      Currency = currency;
    }

    public static bool operator <(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Amount < obj2.Amount;
    }

    public static bool operator <= (Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Amount <= obj2.Amount;
    }

    

    public static bool operator >= (Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Amount >= obj2.Amount;
    }

    public static bool operator >(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return obj1.Amount > obj2.Amount;
    }

    public static Money operator +(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return new Money(obj1.Amount + obj2.Amount, obj1.Currency);
    }


    public static Money operator -(Money obj1, Money obj2)
    {
      ThrowIfCurrencyIsNotMatch(obj1, obj2);

      return new Money(obj1.Amount - obj2.Amount, obj1.Currency);
    }

    private static void ThrowIfCurrencyIsNotMatch(Money obj1, Money obj2)
    {
      if (obj1.Currency != obj2.Currency) throw new CurrencyIsNotMatch();
    }

    public static Money Zero(string currency)
    {
      return new Money(0, currency);
    }

    public override string ToString() => $"{Amount}{Currency}";


    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Math.Round(Amount,8);
      yield return Currency.Trim();
    }
  }
}
