using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();

        for (string line = null; (line = Console.ReadLine()) != string.Empty; )
            numbers.Add(double.Parse(line));

        double sum = numbers.Sum();
        double average = sum / numbers.Count;

        Console.WriteLine("{0} {1}", sum, average);
    }
}
