using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        #if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        var input = Enumerable.Range(0, int.Parse(Console.ReadLine()));
    }
}
