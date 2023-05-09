using Accounting.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data.Configurations
{
  public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.ToTable("Customer", "CustomerContext");
      builder.HasKey(x => x.Id);
      builder.HasIndex(x => x.PhoneNumber).IsUnique();
      builder.HasIndex(x => x.Name).IsUnique();
      builder.HasIndex(x => x.SurName).IsUnique();
      builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
      builder.Property(x => x.SurName).IsRequired().HasMaxLength(50);
    }
  }
}
