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
  public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
  {
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
      builder.HasKey(x => x.Id);
      builder.ToTable("OrderItem", "OrderContext");
      builder.Property(x => x.Description).IsRequired();
      builder.Property(x => x.Quantity).IsRequired();
      builder.Property(x => x.ListPrice).IsRequired();
      builder.Property(x => x.OrderId).IsRequired();
    }
  }
}
