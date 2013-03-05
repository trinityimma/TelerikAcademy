using System;

class Program
{
    static void TestInterest(Account account, int months = 12)
    {
        Console.WriteLine(account.Customer);

        for (int i = 1; i <= months; i++)
            Console.WriteLine(account.CalculateInterest(i));

        Console.WriteLine();
    }

    static void Main()
    {
        {
            Console.WriteLine("# Bank");

            Console.WriteLine(
                new Bank("Prokredit Bank").AddAccount(
                    new DepositAccount(
                        new CompanyCustomer("Telerik"), 0, .1M
                    ).
                    Deposit(150).
                    Withdraw(50),

                    new LoanAccount(
                        new IndividualCustomer("Nakov"), 50, .07M
                    ).
                    Withdraw(20),

                    new MortgageAccount(
                        new IndividualCustomer("Gosho"), 0, .05M
                    )
                )
            );
        }

        {
            //Console.WriteLine("# Calculate Loan account interest");

            //TestInterest(new LoanAccount(
            //    new IndividualCustomer("Nakov"), 100, .1M
            //));

            //TestInterest(new LoanAccount(
            //    new CompanyCustomer("Telerik"), 100, .1M
            //));
        }

        {
            //Console.WriteLine("# Calculate Deposit account interest");

            //TestInterest(new DepositAccount(
            //    new IndividualCustomer("Nakov"), 1000, .1M
            //));

            //TestInterest(new DepositAccount(
            //    new CompanyCustomer("Telerik"), 100, .1M
            //));
        }

        {
            //Console.WriteLine("# Calculate Mortgage account interest");

            //TestInterest(new MortgageAccount(
            //    new IndividualCustomer("Nakov"), 100, .1M
            //));

            //TestInterest(new MortgageAccount(
            //    new CompanyCustomer("Telerik"), 100, .1M
            //), months: 15);
        }
    }
}
