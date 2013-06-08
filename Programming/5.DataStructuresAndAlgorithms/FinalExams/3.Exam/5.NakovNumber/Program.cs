using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var line = new StringBuilder(Console.ReadLine());
        line.Remove(0, 1).Remove(line.Length - 1, 1);

        var input = line.ToString()
            .Split(new[] { "\", \"" }, StringSplitOptions.None)
            .Select(entry => new HashSet<string>(entry.Split()))
            .ToArray();

        var distance = new Dictionary<string, int>();

        var queue = new Queue<string>();

        distance["NAKOV"] = 0;
        queue.Enqueue("NAKOV");

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            foreach (var entry in input.Where(entry => entry.Contains(current)))
            {
                foreach (var name in entry)
                {
                    if (name == current)
                        continue;

                    if (distance.ContainsKey(name))
                        continue;

                    distance[name] = distance[current] + 1;
                    queue.Enqueue(name);
                }
            }
        }

        var result = input
            .SelectMany(name => name)
            .Distinct()
            .OrderBy(name => name)
            .Select(name => string.Format("{0} {1}", name, distance.ContainsKey(name) ? distance[name] : -1));

        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}
