using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string str = "24.01.2013 23:00:00";

        DateTime date = DateTime.Parse(str).AddHours(6).AddMinutes(30);

        Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
    }
}
