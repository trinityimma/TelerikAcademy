using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.ASCII;

        for (int i = 32; i < 127; i++) Console.Write((char)i);
    }
}
