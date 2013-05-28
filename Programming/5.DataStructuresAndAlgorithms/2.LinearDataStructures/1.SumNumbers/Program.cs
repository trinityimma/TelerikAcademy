using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<double> numbers = new LinkedList<double>();

        for (string line = null; (line = Console.ReadLine()) != string.Empty; )
            numbers.AddLast(double.Parse(line));

        double sum = numbers.Sum();
        double average = sum / numbers.Count;

        Console.WriteLine("{0} {1}", sum, average);
    }
}
