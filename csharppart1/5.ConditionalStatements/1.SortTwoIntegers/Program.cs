using System;

class Program
{
    static int[] n = { 1, 0 };

    static void Swap(int i, int j)
    {
        int t = n[i];
        n[i] = n[j];
        n[j] = t;
    }

    static void Main()
    {
        if (n[0] > n[1]) Swap(0, 1);
    }
}
