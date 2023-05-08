using Accounting.Domain.Accounts;
using Accounting.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data.Configurations
{
  public class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransaction>
  {
    public void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {

      builder.HasKey(x => x.Id);
      builder.ToTable("AccountTransaction", "AccountingContext");
      builder.HasOne(d => d.Account).WithMany(p => p.Transactions).HasForeignKey(x=> x.AccountId);
      builder.OwnsOne(x => x.Money).Property(x => x.Amount).HasColumnName("Money_Amount");
      builder.OwnsOne(x => x.Money).Property(x => x.Currency).HasColumnName("Money_Currency");
      builder.OwnsOne(x => x.Type).Property(x=> x.Name).HasColumnName("TransactionTypeName");
      builder.OwnsOne(x => x.Type).Property(x => x.Id).HasColumnName("TransactionTypeId");
      // builder.Ignore(x => x.Type); // Enumarationları Ignore ederiz

    }
  }
}
