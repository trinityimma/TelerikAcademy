using System;

class Program
{
    static void Main()
    {
        BitArray64 used = new BitArray64(10);

        used[0] = true;
        Console.WriteLine(used);
        
        used[0] = false;
        Console.WriteLine(used);
        
        used[used.Count - 1] = true;
        Console.WriteLine(used);
    }
}
