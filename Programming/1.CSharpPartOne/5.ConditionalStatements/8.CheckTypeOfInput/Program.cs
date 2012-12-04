using System;

class Program
{
    static void Main()
    {
        double a;
        string s = Console.ReadLine();
        Console.WriteLine(double.TryParse(s, out a) ? Convert.ToString(a + 1) : s + "*");
    }
}
