using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static List<int> tasks = new List<int>();
    static int variety;

    static int minTasks;

    static void Input()
    {
        foreach (string task in Regex.Split(Console.ReadLine(), ", "))
            tasks.Add(int.Parse(task));

        variety = int.Parse(Console.ReadLine());
    }

    static void FindMinTasks()
    {
        minTasks = tasks.Count;

        for (int i = 0; i < tasks.Count; i++)
        {
            for (int j = i + 1; j < tasks.Count; j++)
            {
                if (Math.Abs(tasks[i] - tasks[j]) < variety) continue;
                
                int currentTasks = (i + 1) / 2 + (j - i + 1) / 2 + 1;

                if (currentTasks < minTasks) minTasks = currentTasks;
            }
        }
    }

    static void Output()
    {
        Console.WriteLine(minTasks);
    }

    static void Main()
    {
#if DEBUG
    Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        Input();

        FindMinTasks();

        Output();
    }
}
