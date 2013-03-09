using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class BitArray : IEnumerable<bool>
{
    private const int CellCapacity = 64;

    private ulong[] array = null;

    public int Length { get; private set; }

    public BitArray(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException();

        this.Length = length;

        int size = (int)Math.Ceiling((double)this.Length / CellCapacity);

        this.array = new ulong[size];
    }

    private void CheckIndex(int i)
    {
        if (!(0 <= i && i < Length))
            throw new IndexOutOfRangeException();
    }

    public bool this[int i]
    {
        get
        {
            CheckIndex(i);

            return ((array[i / CellCapacity] >> (i % CellCapacity)) & 1) == 1;
        }

        set
        {
            CheckIndex(i);

            this.array[i / CellCapacity] = value ?
                (this.array[i / CellCapacity] | 1UL << (i % CellCapacity)) :
                (this.array[i / CellCapacity] & ~(1UL << (i % CellCapacity)));
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
        for (int i = 0; i < Length; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(object obj)
    {
        return Enumerable.SequenceEqual(this.array, (obj as BitArray).array);
    }

    public override int GetHashCode()
    {
        int hash = 17;

        unchecked
        {
            foreach (bool item in this)
                hash = hash * 23 + item.GetHashCode();
        }

        return hash;
    }

    public override string ToString()
    {
        return String.Join<bool>(" ", this);
    }
}
