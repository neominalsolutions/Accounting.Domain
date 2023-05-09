using Accounting.Domain.Accounts;
using Accounting.Domain.Customers;
using Accounting.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class Order:AggregateRoot
  {
    public string CustomerId { get; private set; }
    public Customer Customer { get; set; }

    public DateTime OrderDate { get; private set; }

    public ShipAddress ShipAddress { get; private set; }

    public OrderStatus Status { get; set; }

    private List<OrderItem> _items = new List<OrderItem>();
    public IReadOnlyList<OrderItem> Items => _items;

    public decimal TotalPrice
    {
      get
      {
        return _items.Sum(x => x.Quantity * x.ListPrice);
      }
    }

    public Order()
    {

    }

    public Order(string customerId)
    {
      Id = Guid.NewGuid().ToString();
      OrderDate = DateTime.Now;
      CustomerId = customerId;

    }

    private void AddItem(string description, int quantity, decimal listPrice)
    {
      
      // aynı üründen 1 kerede 20 adet alınmasını engelleyebilirim. Maksimum 

      if (quantity >= 20)
      {
        throw new MaximumStockLimit();
      }

      _items.Add(new OrderItem(Id,description,listPrice,quantity));


    }

    /// <summary>
    /// Order Submit edildikten sonra toplam fiyat hesap bakiyesinden düşülecek
    /// </summary>
    /// <param name="items"></param>
    public void SubmitOrder(Account account,List<OrderItem> items, ShipAddress shipAddress)
    {
      

      foreach (var item in items)
      {
        AddItem(item.Description, item.Quantity, item.ListPrice);
      }

      Status = OrderStatus.Submitted;
      ShipAddress = shipAddress;

      var orderSubmittedEvent = new OrderSubmitted(this,account);
      AddDomainEvent(orderSubmittedEvent);

      
    }
  }
}
