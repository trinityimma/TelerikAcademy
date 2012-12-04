using System;

class Program
{
    static void Main()
    {
        int v = 5, p = 1;
        bool isOne = ((v >> p) & 1) == 1;
    }
}
