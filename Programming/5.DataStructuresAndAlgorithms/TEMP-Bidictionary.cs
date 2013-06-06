using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

class BiDictionary<TKey1, TKey2, TValue>
{
    private class Entry
    {
        public TKey1 Key1 { get; set; }
        public TKey2 Key2 { get; set; }
        public TValue Value { get; set; }

        public Entry(TKey1 key1, TKey2 key2, TValue value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }
    }

    private IDictionary<TKey1, Entry> byKey1 = new Dictionary<TKey1, Entry>();
    private IDictionary<TKey2, Entry> byKey2 = new Dictionary<TKey2, Entry>();
    private IDictionary<Tuple<TKey1, TKey2>, Entry> byFirstAndSecond = new Dictionary<Tuple<TKey1, TKey2>, Entry>();

    public int Count
    {
        get
        {
            Debug.Assert(byKey1.Count == byKey2.Count && byKey2.Count == byFirstAndSecond.Count);

            return this.byFirstAndSecond.Count;
        }
    }

    public void Add(TKey1 key1, TKey2 key2, TValue value)
    {
        var entry = new Entry(key1, key2, value);

        this.byKey1.Add(key1, entry);
        this.byKey2.Add(key2, entry);

        var firstAndSecond = new Tuple<TKey1, TKey2>(key1, key2);
        this.byFirstAndSecond.Add(firstAndSecond, entry);
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

        var firstAndSecond = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
        this.byFirstAndSecond.Remove(firstAndSecond);
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

        var firstAndSecond = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);
        this.byFirstAndSecond.Remove(firstAndSecond);
    }

    public TValue GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var firstAndSecond = new Tuple<TKey1, TKey2>(key1, key2);

        return this.byFirstAndSecond[firstAndSecond].Value;
    }

    public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var firstAndSecond = new Tuple<TKey1, TKey2>(key1, key2);
        var entry = this.byFirstAndSecond[firstAndSecond];

        this.byKey1.Remove(entry.Key1);
        this.byKey2.Remove(entry.Key2);

        this.byFirstAndSecond.Remove(firstAndSecond);
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

        Console.WriteLine(bidictionary.Count);
        bidictionary.RemoveBySecondKey(2);
        Console.WriteLine(bidictionary.Count);

        Console.WriteLine(bidictionary.Count);
        bidictionary.RemoveByFirstAndSecondKey("nakov", 3);
        Console.WriteLine(bidictionary.Count);
    }
}
