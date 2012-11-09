using System;

class Program
{
    static void Main()
    {
        int r = 5;
        int px = 1;
        int py = 1;
        bool isIn = Math.Pow(px, 2) + Math.Pow(py, 2) < Math.Pow(r, 2);
        Console.WriteLine("Is {0}:{1} in radius of {2}: {3}", px, py, r, isIn);
    }
}
