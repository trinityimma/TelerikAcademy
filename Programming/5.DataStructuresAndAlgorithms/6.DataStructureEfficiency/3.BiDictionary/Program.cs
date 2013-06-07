using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class BiDictionary<TKey1, TKey2, TValue>
{
    private struct Entry
    {
        public TKey1 Key1 { get; private set; }

        public TKey2 Key2 { get; private set; }

        public TValue Value { get; private set; }

        public Entry(TKey1 key1, TKey2 key2, TValue value)
            : this()
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }
    }

    private readonly MultiDictionary<TKey1, Entry> byKey1 =
        new MultiDictionary<TKey1, Entry>(true);

    private readonly MultiDictionary<TKey2, Entry> byKey2 =
        new MultiDictionary<TKey2, Entry>(true);

    private readonly MultiDictionary<Tuple<TKey1, TKey2>, Entry> byKey1Key2 =
        new MultiDictionary<Tuple<TKey1, TKey2>, Entry>(true);

    public int Count
    {
        get
        {
            Debug.Assert(
                byKey1.KeyValuePairs.Count == byKey2.KeyValuePairs.Count &&
                byKey2.KeyValuePairs.Count == byKey1Key2.KeyValuePairs.Count
            );

            return this.byKey1Key2.KeyValuePairs.Count;
        }
    }

    public void Add(TKey1 key1, TKey2 key2, TValue value)
    {
        var entry = new Entry(key1, key2, value);

        this.byKey1.Add(key1, entry);
        this.byKey2.Add(key2, entry);

        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);
        this.byKey1Key2.Add(key1key2, entry);
    }

    public ICollection<TValue> GetByFirstKey(TKey1 key1)
    {
        return this.byKey1[key1].Select(entry => entry.Value).ToArray();
    }

    public void RemoveByFirstKey(TKey1 key1)
    {
        var entries = this.byKey1[key1];

        foreach (var entry in entries)
        {
            this.byKey2.Remove(entry.Key2, entry);

            var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
            this.byKey1Key2.Remove(key1key2, entry);
        }

        this.byKey1.Remove(key1);
    }

    public ICollection<TValue> GetBySecondKey(TKey2 key2)
    {
        return this.byKey2[key2].Select(entry => entry.Value).ToArray();
    }

    public void RemoveBySecondKey(TKey2 key2)
    {
        var entries = this.byKey2[key2];

        foreach (var entry in entries)
        {
            this.byKey1.Remove(entry.Key1, entry);

            var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
            this.byKey1Key2.Remove(key1key2, entry);
        }

        this.byKey2.Remove(key2);
    }

    public ICollection<TValue> GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);

        return this.byKey1Key2[key1key2].Select(entry => entry.Value).ToArray();
    }

    public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);
        var entries = this.byKey1Key2[key1key2];

        foreach (var entry in entries)
        {
            this.byKey1.Remove(entry.Key1, entry);
            this.byKey2.Remove(entry.Key2, entry);
        }

        this.byKey1Key2.Remove(key1key2);
    }
}

class Program
{
    static void Main()
    {
        var bidictionary = new BiDictionary<string, int, string>();

        bidictionary.Add("pesho", 1, "javascript");
        bidictionary.Add("gosho", 2, "java");
        bidictionary.Add("nakov", 3, "C#");
        bidictionary.Add("nakov", 3, "C#");
        bidictionary.Add("gosho", 3, "Coffee");
        bidictionary.Add("nakov", 4, "Python");

        Console.WriteLine(string.Join(" ", bidictionary.GetByFirstKey("nakov")));
        Console.WriteLine(string.Join(" ", bidictionary.GetBySecondKey(3)));
        Console.WriteLine(string.Join(" ", bidictionary.GetByFirstAndSecondKey("nakov", 3)));

        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveByFirstKey("pesho");
        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveBySecondKey(3);
        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveByFirstAndSecondKey("nakov", 4);
        Console.WriteLine(bidictionary.Count);
    }
}
