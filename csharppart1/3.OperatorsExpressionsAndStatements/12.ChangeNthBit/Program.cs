// We are given integer number n, value v (v=0 or 1) and a position p. Write a
// sequence of operators that modifies n to hold the value v at the position p
// from the binary representation of n. Example: n = 5 (00000101), p=3, v=1 ->
// 13 (00001101) n = 5 (00000101), p=2, v=0 -> 1 (00000001)

using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int p = 2;
        int v = 0;
        n = (v == 0) ? (n & ~(1 << p)) : (n | 1 << p);
    }
}
