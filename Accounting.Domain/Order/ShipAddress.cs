using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Order
{
  public class ShipAddress : ValueObject
  {
    public string City { get; private set; }
    public string Street { get; private set; }

    public string Country { get; private set; }


    public ShipAddress(string city, string country, string street)
    {
      City = city;
      Country = country;
      Street = street;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return City;
      yield return Country;
      yield return Street;
    }
  }
}
