using System;

class Program
{
    static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (uint j = uint.Parse(Console.ReadLine()); j != 0; j >>= 1)
                if ((j & 1) == b) count++;
            Console.WriteLine(count);
        }
    }
}
