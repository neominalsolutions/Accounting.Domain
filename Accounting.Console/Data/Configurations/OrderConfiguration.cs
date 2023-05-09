using Accounting.Domain.Accounts;
using Accounting.Domain.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("Order", "OrderContext");
      builder.HasKey(x => x.Id);
      builder.OwnsOne(x => x.ShipAddress).Property(x => x.City).HasColumnName("Ship_City");
      builder.OwnsOne(x => x.ShipAddress).Property(x => x.Country).HasColumnName("Ship_Country");
      builder.OwnsOne(x => x.ShipAddress).Property(x => x.Street).HasColumnName("Ship_Street");

      builder.OwnsOne(x => x.Status).Property(x => x.Name).HasColumnName("OrderStatus");
      builder.OwnsOne(x => x.Status).Property(x => x.Id).HasColumnName("OrderCode");



      //account bulduğumuzda account transactions bilgilerini veri tabanından load ederken  _transactions field alanına load et.
      var accountTransactionNavigation =
             builder.Metadata.FindNavigation(nameof(Order.Items));

      accountTransactionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
  }
}
