using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("# Bank");
        Console.WriteLine(
            new Bank("Prokredit Bank").AddAccount(
                new DepositAccount(
                    new CompanyCustomer("Telerik"), 0, .1M
                ).Deposit(150).Withdraw(50),

                new LoanAccount(
                    new IndividualCustomer("Nakov"), 50, .07M
                ).Withdraw(20),

                new MortgageAccount(
                    new IndividualCustomer("Gosho"), 0, .05M
                )
            )
        );

        Console.WriteLine("# Calculate Loan account interest");
        Console.WriteLine(
            new LoanAccount(
                new CompanyCustomer("Telerik"), 500, .1M
            )
            .CalculateInterest(12)
        );

        Console.WriteLine("# Calculate Deposit account interest");
        Console.WriteLine(
            new DepositAccount(
                new CompanyCustomer("Telerik"), 500, .1M
            )
            .Deposit(150)
            .Withdraw(50)
            .CalculateInterest(12)
        );

        Console.WriteLine("# Calculate Mortgage account interest");
        Console.WriteLine(
            new MortgageAccount(
                new CompanyCustomer("Telerik"), 500, .1M
            )
            .CalculateInterest(12)
        );
    }
}
