// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of
// given 32-bit unsigned integer.

using System;

class Program
{
    static int exchange(int n, int i, int j)
    {
        // Swapping two integers
        // i ^= j;
        // j ^= i;
        // i ^= j;
        // Getting the nth byte
        // (n >> i) & 1
        // Setting the nth byte
        // (v == 0) ? (n & ~(1 << p)) : (n | 1 << p)
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << i)) : (n | 1 << i);
        n = ((n >> i) & 1 ^ (n >> j) & 1) == 0 ? (n & ~(1 << j)) : (n | 1 << j);

        // Add leading zeros
        Console.WriteLine(new String('0', 32 - (Convert.ToString(n, 2).Length)) + Convert.ToString(n, 2));
        return n;
    }

    static void Main()
    {
        int n = 56;
        Console.WriteLine(new String('0', 32 - (Convert.ToString(n, 2).Length)) + Convert.ToString(n, 2));
        n = exchange(n, 3, 24);
        n = exchange(n, 4, 25);
        n = exchange(n, 5, 26);
    }
}
