using System;

class Program
{
    static int exchange(int n, int i, int j)
    {
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << i)) : (n | 1 << i);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);
        return n;
    }

    static void Main()
    {
        int n = 56;
        int p = 3;
        int q = 24;
        int k = 3;
        Console.WriteLine(new String('0', 32 - (Convert.ToString(n, 2).Length)) + Convert.ToString(n, 2));

        while (k-- != 0)
        {
            n = exchange(n, p++, q++);
        }

        Console.WriteLine(new String('0', 32 - (Convert.ToString(n, 2).Length)) + Convert.ToString(n, 2));
    }
}
