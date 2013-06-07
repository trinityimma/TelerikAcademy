using System;
using System.Diagnostics;
using System.Collections.Generic;

class BiDictionary<TKey1, TKey2, TValue>
{
    private class Entry
    {
        public TKey1 Key1 { get; private set; }
        public TKey2 Key2 { get; private set; }
        public TValue Value { get; private set; }

        public Entry(TKey1 key1, TKey2 key2, TValue value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }
    }

    private readonly IDictionary<TKey1, Entry> byKey1 = new Dictionary<TKey1, Entry>();
    private readonly IDictionary<TKey2, Entry> byKey2 = new Dictionary<TKey2, Entry>();
    private readonly IDictionary<Tuple<TKey1, TKey2>, Entry> byKey1Key2 = new Dictionary<Tuple<TKey1, TKey2>, Entry>();

    public int Count
    {
        get
        {
            Debug.Assert(byKey1.Count == byKey2.Count && byKey2.Count == byKey1Key2.Count);

            return this.byKey1Key2.Count;
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

    public TValue GetByFirstKey(TKey1 key1)
    {
        return this.byKey1[key1].Value;
    }

    public void RemoveByFirstKey(TKey1 key1)
    {
        var entry = this.byKey1[key1];

        this.byKey1.Remove(entry.Key1);
        this.byKey2.Remove(entry.Key2);

        var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
        this.byKey1Key2.Remove(key1key2);
    }

    public TValue GetBySecondKey(TKey2 key2)
    {
        return this.byKey2[key2].Value;
    }

    public void RemoveBySecondKey(TKey2 key2)
    {
        var entry = this.byKey2[key2];

        this.byKey1.Remove(entry.Key1);
        this.byKey2.Remove(entry.Key2);

        var key1key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
        this.byKey1Key2.Remove(key1key2);
    }

    public TValue GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);

        return this.byKey1Key2[key1key2].Value;
    }

    public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);
        var entry = this.byKey1Key2[key1key2];

        this.byKey1.Remove(entry.Key1);
        this.byKey2.Remove(entry.Key2);

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

        Console.WriteLine(bidictionary.GetByFirstAndSecondKey("nakov", 3));
        Console.WriteLine(bidictionary.GetByFirstKey("nakov"));
        Console.WriteLine(bidictionary.GetBySecondKey(3));

        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveByFirstKey("pesho");
        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveBySecondKey(2);
        Console.WriteLine(bidictionary.Count);

        bidictionary.RemoveByFirstAndSecondKey("nakov", 3);
        Console.WriteLine(bidictionary.Count);
    }
}
