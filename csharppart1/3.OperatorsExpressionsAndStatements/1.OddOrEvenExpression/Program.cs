﻿using System;

class Program
{
    static void Main()
    {
        int a = 5;
        bool parity = (a & 1) == 1;
        Console.WriteLine("{0} is odd: {1}", a, parity);
    }
}