using System;

class Program
{
    static void Main()
    {
        int n = 10, k = 8;
        int factorial = 1;
        for (int i = 0; i < n - k; i++) factorial *= n - i; // n(n - 1)(n - 2) ... (n - k + 1), k = n - k
    }
}
