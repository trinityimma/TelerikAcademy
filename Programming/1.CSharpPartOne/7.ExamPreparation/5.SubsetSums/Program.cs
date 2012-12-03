using System;

class Program
{
    static long[] n = new long[16];
    static int[] ni = new int[16]; // Combination indeces of n, TODO: bit array
    static int k; // (k+1)-combination
    static int l; // n.Length
    static long s; // Required sum
    static int count = 0; // Number of subsets

    static void Check()
    {
        long sum = 0;
        for (int i = 0; i <= k; i++) sum += n[ni[i]];
        if (sum == s) count++;
    }

    static void Combination(int i, int next)
    {
        if (i > k) return;
        for (int j = next; j < l; j++)
        {
            ni[i] = j;
            if (i == k) Check();
            Combination(i + 1, j + 1);
        }
    }

    static void Main()
    {
        s = long.Parse(Console.ReadLine());
        l = int.Parse(Console.ReadLine());
        for (int i = 0; i < l; i++) n[i] = long.Parse(Console.ReadLine());

        for (k = 0; k < l; k++) Combination(0, 0); // Generate combinations of all sizes

        Console.WriteLine(count);
    }
}
