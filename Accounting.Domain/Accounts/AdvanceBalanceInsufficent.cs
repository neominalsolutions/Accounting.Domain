using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class AdvanceBalanceInsufficent:Exception
  {
    public AdvanceBalanceInsufficent():base("advance blance limit is Insufficent")
    {

    }
  }
}
