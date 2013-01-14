using System;

class Program
{
    static void Main()
    {
        int[] n = { 0, 1, 2, 3, 4 };

        int max = n[0];

        for (int i = 1; i < n.Length; i++) max = n[i] > max ? n[i] : max;
    }
}
