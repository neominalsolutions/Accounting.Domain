
using Accounting.Domain.Accounts;

Money m1 = new Money(10.50M, "TL");
var r = m1.Equals(new Money(10.51M, "TL"));
Console.WriteLine(r);

Console.ReadKey();