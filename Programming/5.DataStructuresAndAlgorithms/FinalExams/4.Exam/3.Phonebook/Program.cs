using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

class Entry : IComparable<Entry>
{
    public string Name { get; private set; }
    public ISet<string> Phones { get; private set; }

    public Entry(string name)
    {
        this.Name = name;

        this.Phones = new SortedSet<string>();
    }

    public void AddPhone(string phone)
    {
        this.Phones.Add(phone);
    }

    public override string ToString()
    {
        return string.Format("[{0}: {1}]", this.Name, string.Join(", ", this.Phones));
    }

    public int CompareTo(Entry other)
    {
        return this.Name.CompareTo(other.Name); // TODO: Lower case
    }
}

class Phone
{
    public static string Parse(string s)
    {
        string phone = s;

        phone = Regex.Replace(phone, @"[^0-9\+]", "");

        if (phone.StartsWith("00"))
        {
            phone = phone.Substring(2);
            phone = "+" + phone;
        }

        phone = Regex.Replace(phone, @"^0*", "");

        if (!phone.StartsWith("+"))
        {
            phone = "+359" + phone;
        }

        return phone;
    }
}

class Program
{
    static readonly StringBuilder output = new StringBuilder();

    static readonly OrderedSet<Entry> sorted = new OrderedSet<Entry>();

    static readonly IDictionary<string, Entry> byName =
        new Dictionary<string, Entry>(StringComparer.InvariantCultureIgnoreCase);

    static readonly MultiDictionary<string, Entry> byPhone =
        new MultiDictionary<string, Entry>(false);

    static string AddPhone(string name, IList<string> phones)
    {
        string result;

#if DEBUG
        //Console.WriteLine("Adding {0} - {1}", name, string.Join(", ", phones.Select(Phone.Parse)));
#endif

        if (byName.ContainsKey(name))
        {
            result = "Phone entry merged";
        }

        else
        {
            result = "Phone entry created";

            var entry = new Entry(name);

            byName.Add(name, entry);
            sorted.Add(entry);
        }

        foreach (var phone in phones)
        {
            var phoneParsed = Phone.Parse(phone);

            var entry = byName[name];

            entry.AddPhone(phoneParsed);
            byPhone[phoneParsed].Add(entry);
        }

        return result;
    }

    static string ChangePhone(string oldPhone, string newPhone)
    {
        var oldPhoneParsed = Phone.Parse(oldPhone);
        var newPhoneParsed = Phone.Parse(newPhone);

        int result = byPhone[oldPhoneParsed].Count;

        if (oldPhoneParsed != newPhoneParsed)
        {
            foreach (var entry in byPhone[oldPhoneParsed].ToArray())
            {
                entry.Phones.Remove(oldPhoneParsed);
                entry.Phones.Add(newPhoneParsed);

                byPhone[newPhoneParsed].Add(entry);
            }

            byPhone.Remove(oldPhoneParsed);
        }

        return string.Format("{0} numbers changed", result);
    }

    static string List(int start, int count)
    {
        if (start > byName.Keys.Count || byName.Keys.Count < start + count)
        {
            return "Invalid range";
        }

        var entries = new List<Entry>();

        for (int i = 0; i < count; i++)
        {
            entries.Add(sorted[i + start]);
        }

        return string.Join(Environment.NewLine, entries);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        //Console.WriteLine(Phone.Parse("(02) 981 22 33"));
        //Console.WriteLine(Phone.Parse("123"));
        //Console.WriteLine(Phone.Parse("(+1) 123 456 789"));
        //Console.WriteLine(Phone.Parse("0883 / 456-789"));
        //Console.WriteLine(Phone.Parse("0888 88 99 00"));
        //Console.WriteLine(Phone.Parse("888-88-99-00"));
        //Console.WriteLine(Phone.Parse("+359 (888) 41-80-12"));
        //Console.WriteLine(Phone.Parse("00359 (888) 41-80-12"));
        //Console.WriteLine(Phone.Parse("+359527734522"));
        //Console.WriteLine(Phone.Parse("02 / 981 11 11"));
        //Console.WriteLine(Phone.Parse("0899 777 235"));
        //Console.WriteLine(Phone.Parse("(+359) 899777236"));

        for (string line = null; (line = Console.ReadLine()) != "End"; )
        {
            var match = Regex.Match(line, @"^(\w+)\((.*)\)$").Groups;
            var name = match[1].Value;
            var parameters = Regex.Split(match[2].Value, @",\s?");

            string result = null;

            switch (name)
            {
                case "AddPhone":
                    result = AddPhone(parameters[0], parameters.Skip(1).ToArray());
                    break;

                case "ChangePhone":
                    result = ChangePhone(parameters[0], parameters[1]);
                    break;

                case "List":
                    result = List(int.Parse(parameters[0]), int.Parse(parameters[1]));
                    break;

                default:
                    throw new ArgumentException("Invalid command: " + name);
            }

            output.AppendLine(result); // TODO
        }

#if DEBUG
        //var _output = new System.IO.StreamWriter("../../output.txt");
        //Console.SetOut(_output);
#endif

#if !DEBUG
        Console.Write(output.ToString());
#endif

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
        //_output.Dispose();
#endif
    }
}
