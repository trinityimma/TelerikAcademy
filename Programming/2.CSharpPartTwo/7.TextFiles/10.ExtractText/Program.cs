﻿using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("../../input.txt"))
            for (int i; (i = input.Read()) != -1;)
                if (i == '>' && input.Peek() != '<' && input.Peek() != '\n')
                    while ((i = input.Read()) != '<')
                        Console.Write((char)i);

        Console.WriteLine();
    }
}
