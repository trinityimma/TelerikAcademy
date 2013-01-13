using System;

class Program
{
    static void PrintPolynomial(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--) Console.Write(arr[i] + "*x^" + i + (i == 0 ? "\n" : " + "));
    }

    static int[] Add(int[] a, int[] b, bool subtract = false)
    {
        if (a.Length > b.Length) return Add(b, a, subtract); // We want a <= b

        PrintPolynomial(a);
        PrintPolynomial(b);

        int[] result = new int[b.Length];

        int i = 0;

        for (; i < a.Length; i++) result[i] = a[i] + (subtract ? -b[i] : b[i]); // For each digit in both arrays

        for (; i < b.Length; i++) result[i] = subtract ? -b[i] : b[i]; // If the second array has digits left

        return result;
    }

    static int[] Subtract(int[] a, int[] b)
    {
        return Add(a, b, subtract: true);
    }

    // Naive Multiplication - each with each
    public static int[] Multiply(int[] a, int[] b)
    {
        PrintPolynomial(a);
        PrintPolynomial(b);

        int[] result = new int[a.Length + b.Length - 1];

        for (int i = 0; i < a.Length; i++)
            for (int j = 0; j < b.Length; j++)
                result[i + j] += a[i] * b[j];

        return result;
    }

    static void Main()
    {
        PrintPolynomial(Add(new int[] { 2, 0, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 }));
        Console.WriteLine();

        PrintPolynomial(Subtract(new int[] { 2, 0, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 }));
        Console.WriteLine();

        PrintPolynomial(Multiply(new int[] { 2, 1 }, new int[] { 1, 1 }));
        Console.WriteLine();
    }
}
