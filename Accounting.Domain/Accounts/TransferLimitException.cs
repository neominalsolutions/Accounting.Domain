using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class TransferLimitException:Exception
  {
    public TransferLimitException(int limit, string channel, string? message = ""):base($"{message} {channel} maximum transfer limit is {limit}")
    {

    }
  }
}
