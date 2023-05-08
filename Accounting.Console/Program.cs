
using Accounting.Console;
using Accounting.Console.Data;
using Accounting.Domain.Accounts;
using Accounting.Domain.Customers;
using Accounting.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Net;

public class Program
{



  public static void Main(string[] args)
  {
    var host = CreateHostBuilder(args).Build();

    var accountRepo = host.Services.GetRequiredService<IAccountRepository>();
    var db = host.Services.GetRequiredService<AccountingContext>();
    var accountService = host.Services.GetRequiredService<IAccountDomainService>();

    /*
    #region CreateNewAccount

    var account = new Account("111222333444", "TR 111 222 333 444", "1");
    accountRepo.CreateAsync(account).GetAwaiter().GetResult();

    #endregion
    */

    #region ParaYatırma

    try
    {
      var account1 = accountRepo.FindAsync(x => x.AccountNumber == "111222333444").GetAwaiter().GetResult();
      // ATM 30.000 limit
      //account1.Deposit(new Money(35000, "TL"), TransferChannel.ATM);

      // Online 100.000 limit
      // account1.Deposit(new Money(101000, "TL"), TransferChannel.Online);

      // Hafta sonu 5000 limit
      // account1.Deposit(new Money(6000, "TL"), TransferChannel.Online);

      // Double Dispatch domain service
      account1.Deposit(new Money(35000, "TL"), TransferChannel.ATM, accountService);

      var result = db.SaveChangesAsync().GetAwaiter().GetResult();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    


    #endregion

    #region Paraçekme

    try
    {
      // atm 5000
      var account = accountRepo.FindAsync(x => x.AccountNumber == "111222333444").GetAwaiter().GetResult();
      // atm 5000
      //account.WithDraw(money: new Money(50000, "TL"), TransferChannel.ATM);

      // online 100000
      // account.WithDraw(money: new Money(152000, "TL"), TransferChannel.Online);

      // limit üstü para çekme avanj limit kullan
      //account.WithDraw(money: new Money(5750, "TL"), TransferChannel.Online);

      // limit üstü para çekme avans bakiye yetersiz
      account.WithDraw(money: new Money(6300, "TL"), TransferChannel.Online);

      var result = db.SaveChangesAsync().GetAwaiter().GetResult();



    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);

    }

    Console.ReadKey();


    


    #endregion



    //account.Deposit(new Money(1000, "TL"), TransferChannel.Bank);
    //account.WithDraw(new Money(200000, "TL"), TransferChannel.ATM);

  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureServices((hostContext, services) =>
          {
            services.AddDbContext<AccountingContext>();
            services.AddScoped<IAccountRepository, EFAccountRepository>();
            services.AddScoped<ICustomerRepository, EFCustomerRepository>();
            services.AddScoped<IAccountDomainService, AccountDomainService>();
            services.AddMediatR(opt =>
            {
              opt.RegisterServicesFromAssemblyContaining<Account>();
            });
            // remove the hosted service
            // services.AddHostedService<Worker>();

            // register your services here.
          });


}