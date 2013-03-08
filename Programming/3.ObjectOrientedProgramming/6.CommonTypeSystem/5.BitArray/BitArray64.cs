using System;
using System.Collections;
using System.Collections.Generic;

// TODO: Make it resizable
class BitArray64 : IEnumerable<bool>
{
    private const int MaxCapacity = 64;

    private ulong array = 0;

    public int Count { get; private set; }

    public BitArray64(int capacity)
    {
        if (capacity > MaxCapacity)
            throw new ArgumentOutOfRangeException();

        this.Count = capacity;
    }

    private void CheckIndex(int i)
    {
        if (!(0 <= i && i < Count))
            throw new IndexOutOfRangeException();
    }

    public bool this[int i]
    {
        get
        {
            CheckIndex(i);

            return ((array >> i) & 1) == 1;
        }

        set
        {
            CheckIndex(i);

            this.array = (value == false) ? (this.array & ~(1UL << i)) : (this.array | 1UL << i);
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
        for (int i = 0; i < Count; i++)
            yield return this[i];
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
        return String.Join<bool>(" ", this);
    }
}
