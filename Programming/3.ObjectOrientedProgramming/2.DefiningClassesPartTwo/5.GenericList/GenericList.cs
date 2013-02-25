using System;

class GenericList<T> where T : IComparable<T>
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

    public void Add(T element)
    {
        this.count++;

        Reserve(this.count);

        this.elements[this.count - 1] = element;
    }

    public void Remove(uint index)
    {
        if (index >= this.count)
            throw new IndexOutOfRangeException();

        this.count--;

        Array.Copy(elements, index + 1, elements, index, count - index);

        Reserve(this.count);
    }

    public void Insert(uint index, T element)
    {
        if (index > this.count)
            throw new IndexOutOfRangeException();

        this.count++;

        Reserve(this.count);

        Array.Copy(elements, index, elements, index + 1, count - index);

        this.elements[index] = element;
    }

    public void Clear()
    {
        this.capacity = 0;
        this.count = 0;

        elements = new T[this.capacity];
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < count; i++)
            if (this.elements[i].Equals(element))
                return i;

        return -1;
    }

    public T Min()
    {
        T min = this.elements[0];

        for (int i = 1; i < this.Count; i++)
            if (this.elements[i].CompareTo(min) < 0)
                min = this.elements[i];

        return min;
    }

    public T Max()
    {
        T max = this.elements[0];

        for (int i = 1; i < this.Count; i++)
            if (this.elements[i].CompareTo(max) > 0)
                max = this.elements[i];

        return max;
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
