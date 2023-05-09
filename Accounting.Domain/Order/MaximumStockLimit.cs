using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class MaximumStockLimit:Exception
  {
    public MaximumStockLimit():base("Maksimum stok limit 20 quantity per order")
    {

    }
  }
}
