using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

class Entry
{
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
        return string.Join(" | ", this.Name, this.Town, this.Phone);
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

    static void Main(string[] args)
    {
        Console.SetIn(new System.IO.StringReader(
@"Mimi Shmatkata        | Plovdiv  | 0888 12 34 56
Kireto                  | Varna    | 052 23 45 67
Daniela Ivanova Petrova | Karnobat | 0899 999 888
Bat Gancho              | Sofia    | 02 946 946 946
Bat Gancho              | Plovdiv  | 02 946 946 946
"));

        for (string line = null; (line = Console.ReadLine()) != null; )
        {
            var parts = Regex.Split(line, @"\s*\u007c\s*");

            Add(parts[0], parts[1], parts[2]);
        }

        Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho")));

        Console.WriteLine();

        Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho", "Sofia")));
    }
}
