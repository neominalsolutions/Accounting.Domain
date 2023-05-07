using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounting.Domain.Customers
{
  public class Phone : ValueObject
  {
    public String Value { get; private set; }
    public String AreaCode { get; private set; }

    public String PhoneNumberWithAreaCode
    {
      get
      {
        return $"{AreaCode}{Value}";
      }
    }

    public Phone(String value, String areaCode)
    {
      SetPhoneNumber(value);
      SetAreaCode(areaCode);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
      yield return AreaCode;
    }

    public void SetAreaCode(String areaCode)
    {
      if (string.IsNullOrEmpty(areaCode))
      {
        throw new ArgumentException("Area kod boş geçilemez");
      }

      AreaCode = areaCode;
    }

    public void SetPhoneNumber(String value)
    {
      if (!Regex.IsMatch(value, "^\\+?[1-9][0-9]{7,14}$"))
      {
        throw new PhoneNumberIsNotValid();
      }

      Value = value;
    }
  }
}
