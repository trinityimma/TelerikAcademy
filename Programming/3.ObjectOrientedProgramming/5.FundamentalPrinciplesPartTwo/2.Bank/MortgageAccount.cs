using System;

class MortgageAccount : Account
{
    public MortgageAccount(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public override decimal CalculateInterest(decimal months)
    {
        if (this.Customer is IndividualCustomer)
            return base.CalculateInterest(months - 6);

        if (this.Customer is CompanyCustomer)
            return base.CalculateInterest(Math.Min(months, 12) / 2 + Math.Max(months - 12, 0));

        return base.CalculateInterest(months);
    }

    public override string ToString()
    {
        return base.ToString("Mortgage Account");
    }
}
