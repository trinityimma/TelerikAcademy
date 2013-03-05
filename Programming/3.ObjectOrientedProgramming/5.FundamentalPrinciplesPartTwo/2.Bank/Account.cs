using System;
using System.Collections.Generic;

abstract class Account
{
    public Customer Customer { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal InterestRate { get; protected set; }

    public Account(Customer customer, decimal balance, decimal interest)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interest;
    }

    public Account Withdraw(decimal amount)
    {
        if (this.Balance < amount)
            throw new ArgumentOutOfRangeException("Can not withdraw that ammount!");

        this.Balance -= amount;

        return this;
    }

    public virtual decimal CalculateInterest(decimal months)
    {
        if (!(months > 0))
            return 0;

        return this.Balance * this.InterestRate * months;
    }

    public string ToString(string type)
    {
        List<string> info = new List<string>();

        info.Add(String.Empty); // Add empty line
        info.Add("Type: " + type);
        info.Add("Customer: ");
        info.Add(this.Customer.ToString());
        info.Add("Balance: " + this.Balance);
        info.Add("Interest rate: " + this.InterestRate);

        return String.Join(Environment.NewLine, info);
    }
}
