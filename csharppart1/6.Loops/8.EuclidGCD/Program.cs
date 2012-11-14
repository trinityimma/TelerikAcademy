using System;

class Program
{
    static void Main()
    {
        int k = 30, n = 100;
        while (k != 0)
        {
            int k1 = k;
            k = n % k;
            n = k1;
        }
    }
}
