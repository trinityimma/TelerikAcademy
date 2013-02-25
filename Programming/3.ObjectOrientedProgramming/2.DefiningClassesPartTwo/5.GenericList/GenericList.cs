using System;
using System.Linq;

class GenericList<T>
{
    // Private Constants
    private const uint DefaultCapacity = 1;

    // Private Fields
    private T[] elements = null;
    private uint count = 0;
    private uint capacity = 0;

    // Public Properties
    public uint Count
    {
        get { return this.count; }
    }

    public uint Capacity
    {
        get { return this.capacity; }
    }

    // Constructors
    public GenericList(uint capacity = DefaultCapacity)
    {
        this.capacity = capacity;
        this.count = 0;

        elements = new T[this.capacity];
    }

    // Methods
    private void Reserve(uint capacity)
    {
        uint oldCapacity = this.capacity;

        // 1 / 2 = 0
        if (capacity == 0 || capacity == 1)
            this.capacity = 1;

        else if (capacity <= this.capacity / 2)
            this.capacity /= 2;

        else if (capacity > this.capacity)
            this.capacity *= 2;

        if (oldCapacity != this.capacity)
            Array.Resize<T>(ref elements, (int)this.capacity);
    }

    public void Add(T el)
    {
        this.count++;

        Reserve(this.count);

        this.elements[this.count - 1] = el;
    }

    public void Remove(uint i)
    {
        if (i >= this.count)
            throw new IndexOutOfRangeException();

        this.count--;

        Array.Copy(elements, i + 1, elements, i, count - i);

        Reserve(this.count);
    }

    public void Insert(uint i, T el)
    {
        if (i > this.count) // We can insert in the last position
            throw new IndexOutOfRangeException();

        this.count++;

        Reserve(this.count);

        Array.Copy(elements, i, elements, i + 1, count - i);

        this.elements[i] = el;
    }

    public void Clear()
    {
        this.capacity = DefaultCapacity;
        this.count = 0;

        elements = new T[this.capacity];
    }

    public int IndexOf(T el)
    {
        return Array.IndexOf<T>(elements, el);
    }

    //private T MinMax(bool value)
    //{
    //    T best = this.elements[0];

    //    for (int i = 1; i < this.Count; i++)
    //        if (value ? (best < (dynamic)this.elements[i]) : (best > (dynamic)this.elements[i]))
    //            best = this.elements[i];

    //    return best;
    //}

    public T Max()
    {
        return elements.Max<T>();
    }

    public T Min()
    {
        return elements.Min<T>();
    }

    public T this[uint index]
    {
        get
        {
            if (index >= this.count)
                throw new IndexOutOfRangeException();

            return elements[index];
        }
    }

    public override string ToString()
    {
        if (this.count == 0)
            return "Empty list.";

        string[] info = new string[this.count];

        for (int i = 0; i < this.count; i++)
            info[i] = String.Format("{0}: {1}", i, this.elements[i].ToString());

        return String.Join(Environment.NewLine, info);
    }
}
