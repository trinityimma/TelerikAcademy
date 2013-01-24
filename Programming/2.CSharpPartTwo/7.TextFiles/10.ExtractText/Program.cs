using System;
using System.IO;

class Program
{
    static void Main()
    {
        // TODO: Skip whitespace
        using (StreamReader input = new StreamReader("../../input.txt"))
            for (int i; (i = input.Read()) != -1;) // Read char by char
                if (i == '>' && input.Peek() != '<' && input.Peek() != '\r' && input.Peek() != '\n')
                    while ((i = input.Read()) != '<') // Inside text node
                        Console.Write((char)i);

        Console.WriteLine();
    }
}
