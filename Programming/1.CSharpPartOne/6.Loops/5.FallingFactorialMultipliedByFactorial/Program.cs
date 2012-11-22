using System;

class Program
{
    static void Main()
    {
        int n = 10, k = 3;
        int factorial = 1;
        for (int i = 0; i < k; i++) factorial *= n - i; // n(n - 1)(n - 2) ... (n - k + 1)
        for (int i = 1; i <= k; i++) factorial *= i; // * k!
    }
}
