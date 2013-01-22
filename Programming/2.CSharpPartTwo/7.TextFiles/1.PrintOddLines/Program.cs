using System;
using System.IO;

class Program
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("../../Program.cs"))
            for (string line; (line = input.ReadLine()) != null; n++)
                if (n % 2 == 1) Console.WriteLine(line);
    }
}
