using System;

class Program
{
    static void PrintNumber(byte[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--) Console.Write(arr[i]); // Reversed

        Console.WriteLine();
    }

    static byte[] Add(byte[] a, byte[] b)
    {
        if (a.Length > b.Length) return Add(b, a); // We want a <= b

        PrintNumber(a);
        PrintNumber(b);

        byte[] result = new byte[b.Length + 1]; // 1 + 99 = 100

        int i = 0, carry = 0;

        // For each digit in both arrays
        for (; i < a.Length; i++)
        {
            result[i] = (byte)(a[i] + b[i] + carry);

            carry = result[i] / 10;
            result[i] %= 10;
        }

        // If there is still a carry
        for (; i < b.Length && carry != 0; i++)
        {
            result[i] = (byte)(b[i] + carry);

            carry = result[i] / 10;
            result[i] %= 10;
        }

        // If the second array has digits left
        for (; i < b.Length; i++) result[i] = b[i];

        // If there is still a carry
        if (carry != 0) result[i] = 1;
        else Array.Resize(ref result, result.Length - 1); // Last digit not needed

        return result;
    }

    // Tests
    static void Main()
    {
        PrintNumber(Add(new byte[] { 0 }, new byte[] { 0 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 1 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 0, 1 }, new byte[] { 1 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 9 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9, 8 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9, 8, 7, 6 }));
        Console.WriteLine();

        PrintNumber(Add(new byte[] { 2, 1 }, new byte[] { 8, 8, 9, 9, 9, 8, 1 }));
        Console.WriteLine();
    }
}
