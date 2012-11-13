using System;

class Program
{
    static int[] n = { 0, 2, 1 };

    static void Swap(int i, int j)
    {
        int t = n[i];
        n[i] = n[j];
        n[j] = t;
    }

    static void Main()
    {
        if (n[0] < n[1])
            if (n[1] < n[2]) Swap(0, 2); // 012
            else if (n[0] < n[2]) // 021
            {
                Swap(0, 1);
                Swap(1, 2);
            }
            else Swap(0, 1); // 120
        else
            if (n[0] < n[2]) // 102
            {
                Swap(0, 1);
                Swap(0, 2);
            }
            else if (n[1] < n[2]) Swap(1, 2); // 201
            else ; // 210
    }
}
