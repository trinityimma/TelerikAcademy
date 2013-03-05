using System;

class DepositAccount : Account
{
    public DepositAccount(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public DepositAccount Deposit(decimal amount)
    {
        this.Balance += amount;

        return this;
    }

    public override decimal CalculateInterest(decimal months)
    {
        if (0 < this.Balance && this.Balance < 1000)
            return 0;

        return base.CalculateInterest(months);
    }

    public override string ToString()
    {
        return base.ToString("Deposit Account");
    }
}
