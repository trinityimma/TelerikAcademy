using System;
using System.IO;

class Program
{
    static void Main()
    {
        int n = 0, same = 0;

        using (StreamReader input1 = new StreamReader("../../input1.txt"))
        using (StreamReader input2 = new StreamReader("../../input2.txt"))
            for (string line1, line2; (line1 = input1.ReadLine()) != null && (line2 = input2.ReadLine()) != null; n++)
                if (line1 == line2) same++;

        Console.WriteLine("{0}  {1}", same, n - same);
    }
}
