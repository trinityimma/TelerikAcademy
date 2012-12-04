using System;

class Program
{
    static void Main()
    {
        int score = int.Parse(Console.ReadLine());
        if (score > 0 && score < 10)
        {
            score *= 10;
            if (score > 30) score *= 10;
            if (score > 600) score *= 10;
        }
        else Console.Error.WriteLine("Error");
    }
}
