using System;

class DepositAccount : Account
{
    private const decimal MinBalanceForInterest = 1000M;

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
        if (this.Balance < MinBalanceForInterest)
            return 0;

        return base.CalculateInterest(months);
    }

    public override string ToString()
    {
        return base.ToString("DepositAccount");
    }
}
