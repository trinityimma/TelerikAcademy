using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.ASCII;
        for (int i = 0; i < 128; i++)
        {
            Console.Write((char)i);
        }
    }
}
