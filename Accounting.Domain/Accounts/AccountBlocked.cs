﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Accounts
{
  public class AccountBlocked:Exception
  {
    public AccountBlocked():base("Account is blocked")
    {

    }
  }
}
