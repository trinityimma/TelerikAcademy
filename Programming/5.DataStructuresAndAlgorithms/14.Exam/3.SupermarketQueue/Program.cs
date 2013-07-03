using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

public static class Program
{
    static BigList<string> data = new BigList<string>();

    static Bag<string> names = new Bag<string>();

    static StringBuilder output = new StringBuilder();

    static string Append(string name)
    {
        names.Add(name);

        data.Add(name);

        return "OK";
    }

    static string Insert(int position, string name)
    {
        if (position > data.Count)
            return "Error";

        names.Add(name);

        data.Insert(position, name);

        return "OK";
    }

    static string Find(string name)
    {
        var result = names.NumberOfCopies(name);

        return result.ToString();
    }

    static string Serve(int count)
    {
        if (count > data.Count)
            return "Error";

        var matched = data.Take(count).ToArray();

        data.RemoveRange(0, count);

        foreach (var name in matched)
            names.Remove(name);

        var result = string.Join(" ", matched);
        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var separator = new[] { ' ' };

        for (string line; (line = Console.ReadLine()) != "End"; )
        {
            var splitted = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var name = splitted[0];

            string result;

            switch (name)
            {
                case "Append":
                    result = Append(name: splitted[1]);
                    break;

                case "Insert":
                    result = Insert(position: int.Parse(splitted[1]), name: splitted[2]);
                    break;

                case "Find":
                    result = Find(name: splitted[1]);
                    break;

                case "Serve":
                    result = Serve(count: int.Parse(splitted[1]));
                    break;

                default:
                    throw new ArgumentException("Invalid command name: " + name);
            }

            output.AppendLine(result);
        }

        Console.Write(output);
    }
}