using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class TransferChannel: Enumeration
  {
    
      public static TransferChannel Bank = new(1, nameof(Bank));
      public static TransferChannel Online = new(2, nameof(Online));
      public static TransferChannel ATM = new(3, nameof(ATM));

      public TransferChannel(int id, string name)
          : base(id, name)
      {
      }
    
  }
}
