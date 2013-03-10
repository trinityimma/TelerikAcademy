using System;

class Program
{
    static void Main()
    {
        BitArray used = new BitArray(65);

        used[1] = true;
        Console.WriteLine(used);

        Console.WriteLine();

        used[1] = false;
        Console.WriteLine(used);

        Console.WriteLine();
        
        used[used.Length - 1] = true;
        Console.WriteLine(used);
    }
}
