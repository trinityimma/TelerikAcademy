using System;

class GenericList<T> where T : IEquatable<T>, IComparable<T>
{
    const uint DefaultCapacity = 1;

    private T[] elements = null;
    private uint count = 0;
    public uint capacity = 0;

    public GenericList(uint capacity = DefaultCapacity)
    {
        this.capacity = capacity;

        elements = new T[this.capacity];
    }

    private void EnsureCapacity(uint capacity)
    {
        if (capacity < this.capacity / 2)
            this.capacity /= 2;

        if (capacity > this.capacity)
            this.capacity *= 2;

        T[] newElements = new T[this.capacity];

        for (int i = 0; i < this.count; i++)
            newElements[i] = elements[i];

        this.elements = newElements;
    }

    public uint Count
    {
        get { return this.count; }
    }

    public void Add(T element)
    {
        EnsureCapacity(this.count + 1);

        this.elements[this.count] = element;

        this.count++;
    }

    public void Remove(uint index)
    {
        if (index >= this.count)
            throw new IndexOutOfRangeException();

        this.count--;

        for (uint i = index + 1; i < this.count; i++)
            this.elements[i - 1] = this.elements[i];

        EnsureCapacity(this.count);
    }

    public void Insert(uint index, T element)
    {
        if (index >= this.count)
            throw new IndexOutOfRangeException();

        this.count++;

        EnsureCapacity(this.count);

        for (uint i = this.count; i > index; i--)
            this.elements[i] = this.elements[i - 1];

        this.elements[index] = element;
    }

    public void Clear()
    {
        this.capacity = DefaultCapacity;
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

        for (int i = 0; i < this.Count; i++)
            if (this.elements[i].CompareTo(min) < 0)
                min = this.elements[i];

        return min;
    }

    public T Max()
    {
        T max = this.elements[0];

        for (int i = 0; i < this.Count; i++)
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
        string[] info = new string[this.count];

        for (int i = 0; i < this.count; i++)
            info[i] = String.Format("{0}: {1}", i, this.elements[i].ToString());

        return String.Join(Environment.NewLine, info);
    }
}
