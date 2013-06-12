using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Entry
{
    public const string Separator = " | ";

    public string Name { get; private set; }
    public string Town { get; private set; }
    public string Phone { get; private set; }

    public Entry(string name, string town, string phone)
    {
        this.Name = name;
        this.Town = town;
        this.Phone = phone;
    }

    public override string ToString()
    {
        return string.Join(Entry.Separator, this.Name, this.Town, this.Phone);
    }
}

class Program
{
    static MultiDictionary<string, Entry> byName =
        new MultiDictionary<string, Entry>(true);

    static MultiDictionary<Tuple<string, string>, Entry> byNameAndTown =
        new MultiDictionary<Tuple<string, string>, Entry>(true);

    static void Add(string name, string town, string phone)
    {
        var entry = new Entry(name, town, phone);

        var nameAndTown = new Tuple<string, string>(entry.Name, entry.Town);

        byName.Add(name, entry);
        byNameAndTown.Add(nameAndTown, entry);
    }

    static IEnumerable<Entry> Find(string name)
    {
        return byName[name];
    }

    static IEnumerable<Entry> Find(string name, string town)
    {
        var nameAndTown = new Tuple<string, string>(name, town);

        return byNameAndTown[nameAndTown];
    }

    static void Main()
    {
        using (var input = new StreamReader("../../input.txt"))
        {
            for (string line = null; (line = input.ReadLine()) != null; )
            {
                var parts = line.Split(new[] { Entry.Separator }, StringSplitOptions.None)
                    .Select(entry => entry.Trim())
                    .ToArray();

                Add(parts[0], parts[1], parts[2]);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho")));

        Console.WriteLine();

        Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho", "Sofia")));
    }
}
