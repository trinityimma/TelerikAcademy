using System;
using System.Collections;
using System.Collections.Generic;

class BitArray : IEnumerable<bool>
{
    private const int Capacity = 64;

    private ulong[] array = null;

    public int Count { get; private set; }

    public BitArray(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException();

        this.Count = count;

        int length = (int)Math.Ceiling((double)this.Count / Capacity);

        this.array = new ulong[length];
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

            return ((array[i / Capacity] >> (i % Capacity)) & 1) == 1;
        }

        set
        {
            CheckIndex(i);

            this.array[i / Capacity] = value ?
                (this.array[i / Capacity] | 1UL << (i % Capacity)) :
                (this.array[i / Capacity] & ~(1UL << (i % Capacity)));
        }
    }

    public static bool operator ==(BitArray array1, BitArray array2)
    {
        return BitArray.Equals(array1, array2);
    }

    public static bool operator !=(BitArray array1, BitArray array2)
    {
        return !BitArray.Equals(array1, array2);
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
        return this.array.Equals((obj as BitArray).array);
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
