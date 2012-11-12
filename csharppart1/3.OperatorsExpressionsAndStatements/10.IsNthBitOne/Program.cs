using System;

class Program
{
    static void Main()
    {
        int v = 5;
        int p = 1;
        bool isOne = ((v >> p) & 1) == 1;
    }
}
