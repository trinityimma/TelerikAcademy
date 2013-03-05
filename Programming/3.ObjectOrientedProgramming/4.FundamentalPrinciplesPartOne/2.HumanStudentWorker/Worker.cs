using System;
using System.Text;

class Worker : Human
{
    private const int DefaultWorkDaysInWeek = 5;

    public decimal WeekSalary { get; private set; }
    public decimal WorkHoursPerDay { get; private set; }
    public int WorkDaysInWeek { get; private set; }

    public Worker(string firstName, string lastName,
        decimal weekSalary, decimal workHoursPerDay, int workDaysInWeek = DefaultWorkDaysInWeek
    )
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
        this.WorkDaysInWeek = workDaysInWeek;
    }

    public decimal GetMoneyPerHour()
    {
        return this.WeekSalary / this.WorkDaysInWeek / this.WorkHoursPerDay;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("Week salary: " + this.WeekSalary);
        info.AppendLine("Work hours per day: " + this.WorkHoursPerDay);
        info.AppendFormat("Money per hour: {0:0.000}", this.GetMoneyPerHour()).AppendLine();

        return base.ToString(info.ToString());
    }
}
