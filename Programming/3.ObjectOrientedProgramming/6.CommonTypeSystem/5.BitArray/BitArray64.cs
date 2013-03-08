using System;
using System.Collections;
using System.Collections.Generic;

// TODO: Make it resizable
class BitArray64 : IEnumerable<bool>
{
    private const int DefaultCapacity = 10;

    private ulong array = 0;

    public int Count { get; private set; }
    
    public BitArray64(int capacity = DefaultCapacity)
    {
        this.Count = capacity;
    }

    public bool this[int index]
    {
        get
        {
            if (!(0 <= index && index < this.Count))
                throw new IndexOutOfRangeException();

            return ((array >> index) & 1) == 1;
        }
        set
        {
            if (!(0 <= index && index < this.Count))
                throw new IndexOutOfRangeException();

            this.array = (value == false) ? (this.array & ~(1UL << index)) : (this.array | 1UL << index);
        }
    }

    public static bool operator ==(BitArray64 array1, BitArray64 array2)
    {
        return BitArray64.Equals(array1, array2);
    }

    public static bool operator !=(BitArray64 array1, BitArray64 array2)
    {
        return !BitArray64.Equals(array1, array2);
    }

    public IEnumerator<bool> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
            yield return ((array >> i) & 1) == 1;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(object obj)
    {
        return this.array.Equals((obj as BitArray64).array);
    }

    public override int GetHashCode()
    {
        return this.array.GetHashCode();
    }

    public override string ToString()
    {
        return String.Join<bool>(Environment.NewLine, this);
    }
}
