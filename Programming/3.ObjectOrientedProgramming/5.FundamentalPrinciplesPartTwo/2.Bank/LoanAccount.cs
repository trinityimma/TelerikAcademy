using System;

class LoanAccount : Account
{
    private const int SkipIndividualCustomerMonths = 3;
    private const int SkipCompanyCustomerMonths = 2;

    public LoanAccount(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public override decimal CalculateInterest(decimal months)
    {
        if (this.Customer is IndividualCustomer)
            return base.CalculateInterest(months - SkipIndividualCustomerMonths);

        if (this.Customer is CompanyCustomer)
            return base.CalculateInterest(months - SkipCompanyCustomerMonths);

        else
            return base.CalculateInterest(months);
    }

    public override string ToString()
    {
        return base.ToString("LoanAccount");
    }
}
