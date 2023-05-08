using Accounting.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data.Configurations
{
  public class AccountConfiguration : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> builder)
    {
      builder.ToTable("Account", "AccountingContext");
      builder.HasKey(x => x.Id);
      builder.HasIndex(x => x.IBAN).IsUnique();
      builder.HasIndex(x => x.AccountNumber).IsUnique();
      builder.Property(x => x.AccountNumber).IsRequired();
      builder.Property(x => x.IBAN).IsRequired();
      builder.OwnsOne(x => x.Balance).Property(x => x.Amount).HasColumnName("Balance_Amount");
      builder.OwnsOne(x => x.Balance).Property(x => x.Currency).HasColumnName("Balance_Currency");
      builder.OwnsOne(x => x.AdvanceAccountLimit).Property(x => x.Amount).HasColumnName("AdvanceAccount_Limit");
      builder.OwnsOne(x => x.AdvanceAccountLimit).Property(x => x.Currency).HasColumnName("AdvanceAccount_LimitCurrency");


      builder.HasOne(x => x.Customer).WithMany(x => x.Accounts).HasForeignKey(x => x.CustomerId);
     

      //account bulduğumuzda account transactions bilgilerini veri tabanından load ederken  _transactions field alanına load et.
      var accountTransactionNavigation =
             builder.Metadata.FindNavigation(nameof(Account.Transactions));

      accountTransactionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

    }
  }
}
