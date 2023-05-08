using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class CustomerAccountIsNotValid:Exception
  {
    public CustomerAccountIsNotValid():base("Customer account isn't valid")
    {

    }
  }
}
