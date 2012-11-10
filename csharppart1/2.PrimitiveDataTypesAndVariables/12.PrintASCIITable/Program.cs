// Find online more information about ASCII (American Standard Code for
// Information Interchange) and write a program that prints the entire ASCII
// table of characters on the console.

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
