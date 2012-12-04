using System;

class Program
{
    static int[] n = { 3, -2, 1, 1, 8 };
    static int[] m = new int[5]; // Combination indeces of n, TODO: bit array
    static int k; // (k+1)-combination

    static void Check()
    {
        int sum = 0;
        for (int i = 0; i <= k; i++) sum += n[m[i]];
        if (sum == 0) for (int i = 0; i <= k; i++) Console.Write(n[m[i]] + (i == k ? " = 0\n" : " + "));
    }

    static void Combination(int i, int next)
    {
        if (i > k) return;
        for (int j = next; j < n.Length; j++)
        {
            m[i] = j;
            if (i == k) Check();
            Combination(i + 1, j + 1);
        }
    }

    static void Main()
    {
        for (k = 0; k < n.Length; k++) Combination(0, 0); // Generate combinations of all sizes
    }
}
