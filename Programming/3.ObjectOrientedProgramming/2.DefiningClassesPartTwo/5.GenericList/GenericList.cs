using System;

class GenericList<T>
{
    // Private Constants
    private const uint DefaultCapacity = 1;

    // Private Fields
    private T[] elements = null;

    // Public Properties
    public uint Count { get; private set; }
    public uint Capacity { get; private set; }

    // Constructors
    public GenericList(uint capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.Count = 0;

        elements = new T[this.Capacity];
    }

    // Methods
    public void Clear()
    {
        this.Capacity = DefaultCapacity;
        this.Count = 0;

        elements = new T[this.Capacity];
    }

    private void Reserve(uint capacity)
    {
        uint oldCapacity = this.Capacity;

        // 1 / 2 = 0
        if (capacity == 0 || capacity == 1)
            this.Capacity = 1;

        else if (capacity <= this.Capacity / 2)
            this.Capacity /= 2;

        else if (capacity > this.Capacity)
            this.Capacity *= 2;

        if (oldCapacity != this.Capacity)
            Array.Resize(ref elements, (int)this.Capacity);
    }

    public void Add(T el)
    {
        this.Count++;

        Reserve(this.Count);

        this.elements[this.Count - 1] = el;
    }

    public void Remove(uint i)
    {
        if (i >= this.Count)
            throw new IndexOutOfRangeException();

        this.Count--;

        Array.Copy(this.elements, i + 1, this.elements, i, Count - i);

        this.elements[this.Count] = default(T); // Clear last

        Reserve(this.Count);
    }

    public void Insert(uint i, T el)
    {
        if (i > this.Count) // We can insert in the last position
            throw new IndexOutOfRangeException();

        this.Count++;

        Reserve(this.Count);

        Array.Copy(elements, i, elements, i + 1, Count - i - 1);

        this.elements[i] = el;
    }

    public int IndexOf(T el)
    {
        return Array.IndexOf(elements, el);
    }

    private T MinMax(bool value)
    {
        T best = this.elements[0];

        for (int i = 1; i < this.Count; i++)
            if (value ? (best < (dynamic)this.elements[i]) : (best > (dynamic)this.elements[i]))
                best = this.elements[i];

        return best;
    }

    public T Max()
    {
        return MinMax(true);
    }

    public T Min()
    {
        return MinMax(false);
    }

    public T this[uint index]
    {
        get
        {
            if (index >= this.Count)
                throw new IndexOutOfRangeException();

            return elements[index];
        }
    }

    public override string ToString()
    {
        if (this.Count == 0)
            return "Empty list.";

        string[] info = new string[this.Count];

        for (int i = 0; i < this.Count; i++)
            info[i] = String.Format("{0}: {1}", i, this.elements[i].ToString());

        return String.Join(Environment.NewLine, info);
    }
}
