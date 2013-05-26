using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        var tasks = new OrderedBag<Tuple<string, int>>((task1, task2) =>
            task1.Item2.CompareTo(task2.Item2) * 2 + task1.Item1.CompareTo(task2.Item1)
        );

        var output = new StringBuilder();

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            string line = Console.ReadLine();

            if (line == "Solve")
            {
                if (tasks.Count == 0)
                {
                    output.AppendLine("Rest");
                    continue;
                }

                var task = tasks.GetFirst();
                tasks.RemoveFirst();

                output.AppendLine(task.Item1);
            }
            else
            {
                var match = line.Split();

                tasks.Add(new Tuple<string, int>(match[2], int.Parse(match[1])));
            }
        }

        Console.Write(output);

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
