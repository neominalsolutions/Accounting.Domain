using Accounting.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Customers
{
  public class Customer:AggregateRoot
  {
    public string Id { get; init; }
    public string Name { get; private set; }
    public string SurName { get; private set; }
    public string PhoneNumber { get; private set; }

    public string FullName { get { return $"{Name} {SurName}"; } }

    public Customer(string name,string surname)
    {
      Id = Guid.NewGuid().ToString();
      this.Name = name;
      this.SurName = surname;

    }

    public void SetName(string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentException("müşteri adı boş geçilemez");
      }

      Name = $"{Name[0].ToString().ToUpper()}{Name.Substring(1, Name.Length - 1)}";
    }

    public void SetSurName(string surname)
    {
      if (string.IsNullOrEmpty(surname))
      {
        throw new ArgumentException("müşteri soyadı boş geçilemez");
      }

      Name = surname.ToUpper().Trim();
    }






  }
}
