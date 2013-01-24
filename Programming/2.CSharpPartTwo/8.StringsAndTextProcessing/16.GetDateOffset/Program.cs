using System;

class Program
{
    static void Main()
    {
        string start = "27.02.2006";
        string end   =  "3.03.2006";

        Console.WriteLine((DateTime.Parse(end) - DateTime.Parse(start)).TotalDays);
    }
}
