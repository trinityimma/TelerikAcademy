using System;

class Program
{
    // Swapping i and j: i ^= j, j ^= i, i ^= j;
    // Getting the pth byte: (n >> p) & 1
    // Setting the pth byte to v: (v == 0) ? (n & ~(1 << p)) : (n | 1 << p)
    static int Exchange(int n, int i, int j)
    {
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << i)) : (n | 1 << i);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

        return n;
    }

    static void Main()
    {
        int n = 56, p = 3, q = 24, k = 3;

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

        while (k-- != 0) n = Exchange(n, p++, q++);
    }
}
