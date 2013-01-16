using System;

class Program
{
    static DateTime[] holidays = { new DateTime(2012, 12, 24), new DateTime(2012, 12, 25), new DateTime(2012, 12, 30), new DateTime(2012, 12, 31), new DateTime(2013, 01, 01) };

    static int FilterHolidays(DateTime start, DateTime end, int result)
    {
        foreach (DateTime holiday in holidays)
            if (start <= holiday && holiday <= end && !(holiday.DayOfWeek == DayOfWeek.Saturday || holiday.DayOfWeek == DayOfWeek.Sunday))
                result--; // Remоve if not already removed and inside of period

        return result;
    }

    static void TrimPeriod(ref DateTime start, ref DateTime end)
    {
        // Trim if it starts with a working day
        if (start.DayOfWeek == DayOfWeek.Saturday) start = start.AddDays(2);
        if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(1);

        // Trim if it ends with a working day
        if (end.DayOfWeek == DayOfWeek.Saturday) end = end.AddDays(-1);
        if (end.DayOfWeek == DayOfWeek.Sunday) end = end.AddDays(-2);
    }

    static int GetWorkDays(DateTime start, DateTime end)
    {
        if (end < start) return GetWorkDays(end, start); // Swap if end is before start

        TrimPeriod(ref start, ref end);

        int offset = (int)(end - start).TotalDays + 1; // Find days between

        int result = offset / 7 * 5 + offset % 7; // Split in weeks with five working days and add remaining

        return FilterHolidays(start, end, Math.Max(result, 0)); // If start and end were in the same weekend
    }

    static void Main()
    {
        Console.WriteLine(GetWorkDays(new DateTime(2012, 12, 20), new DateTime(2013, 01, 5)));
    }
}
