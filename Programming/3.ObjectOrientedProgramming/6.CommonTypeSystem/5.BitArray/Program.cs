using System;

class Program
{
    static void Main()
    {
        BitArray used = new BitArray(65);

        used[0] = true;
        Console.WriteLine(used);

        Console.WriteLine();

        used[0] = false;
        Console.WriteLine(used);

        Console.WriteLine();
        
        // Make a second long
        used[used.Count - 1] = true;
        Console.WriteLine(used);
    }
}
