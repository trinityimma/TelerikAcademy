using System;
using System.IO;

class Program
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("../../Program.cs"))
        using (StreamWriter output = new StreamWriter("../../output.txt"))
            for (string line; (line = input.ReadLine()) != null; n++)
                output.WriteLine("{0}.{1}", n, line);
    }
}
