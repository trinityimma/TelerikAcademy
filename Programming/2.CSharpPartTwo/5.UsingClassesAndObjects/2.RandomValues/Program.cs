using System;

class Program
{
    static void Main()
    {
        var randomGenerator = new Random();

        for (int i = 0; i < 10; i++) Console.WriteLine(randomGenerator.Next(100, 201));
    }
}
