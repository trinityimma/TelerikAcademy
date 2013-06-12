using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private const int DefaultSize = 7;

    private IList<LinkedList<KeyValuePair<TKey, TValue>>> elements = null;

    public HashTable()
    {
        this.elements = Enumerable.Range(0, DefaultSize)
            .Select(i => new LinkedList<KeyValuePair<TKey, TValue>>())
            .ToArray();
    }

    public int Count
    {
        get { return this.elements.Select(list => list.Count).Sum(); }
    }

    public ICollection<TKey> Keys
    {
        get { return this.elements.SelectMany(els => els.Select(el => el.Key)).ToArray(); }
    }

    private int GetIndex(TKey key)
    {
        var hash = key.GetHashCode() & int.MaxValue; // Math.Abs
        var index = hash % this.elements.Count;

        return index;
    }

    private KeyValuePair<TKey, TValue> GetKey(TKey key, int index)
    {
        return this.elements[index].First(kvp => kvp.Key.Equals(key));
    }

    public bool Remove(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException("key");

        var index = this.GetIndex(key);

        try
        {
            var result = this.GetKey(key, index);
            this.elements[index].Remove(result);

            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            if (key == null)
                throw new ArgumentNullException("key");

            var index = this.GetIndex(key);

            KeyValuePair<TKey, TValue> result;

            try
            {
                result = this.GetKey(key, index);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Missing key.");
            }

            return result.Value;
        }
        set
        {
            if (key == null)
                throw new ArgumentNullException("key");

            var index = this.GetIndex(key);

            var element = new KeyValuePair<TKey, TValue>(key, value);
            this.elements[index].AddLast(element);
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return this.elements.SelectMany(el => el).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
