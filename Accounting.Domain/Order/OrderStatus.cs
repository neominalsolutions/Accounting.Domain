using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class OrderStatus : Enumeration
  {
    public static OrderStatus Submitted = new(100, nameof(Submitted));
    public static OrderStatus Shipped = new(300, nameof(Shipped));
    public static OrderStatus Cancelled = new(400, nameof(Cancelled));
    public static OrderStatus Invoiced = new(500, nameof(Invoiced));
    public OrderStatus(int id, string name) : base(id, name)
    {
    }
  }
}
