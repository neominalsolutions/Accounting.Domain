using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Customers
{
  public class PhoneNumberIsNotValid:Exception
  {
    public PhoneNumberIsNotValid() : base("The phone number isn't valid.")
    {
    }
  }
}
