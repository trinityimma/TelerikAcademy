using System;

class MortgageAccount : Account
{
    public MortgageAccount(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    // TODO: Constants
    public override decimal CalculateInterest(decimal months)
    {
        if (this.Customer is CompanyCustomer)
        {
            decimal p = ((months % 12) / 2) + (months - 12);
            return base.CalculateInterest(p);
        }

        if (this.Customer is IndividualCustomer)
            return base.CalculateInterest(months - 6);

        else
            return base.CalculateInterest(months);
    }

    public override string ToString()
    {
        return base.ToString("MortgageAccount");
    }
}
