using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class OrderItem:Entity<string>
  {
   
    public string OrderId { get; set; }
    public string Description { get; set; } // Hizmet
    public decimal ListPrice { get; set; }
    public int Quantity { get; set; }


    public OrderItem()
    {
 

    }

    public OrderItem(string orderId, string description , decimal listPrice, int quantity)
    {
      Id = Guid.NewGuid().ToString();
      OrderId = orderId;
      Description = description;
      ListPrice = listPrice;
      Quantity = quantity;
    }
  }
}

