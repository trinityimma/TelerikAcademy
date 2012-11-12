using System;

class Program
{
    // Source: http://projecteuler.net/problem=7
    static bool IsPrime(int n)
    {
        if (n == 1)
        {
            return false;
        }
        if (n < 4)
        {
            return true;
        }
        if ((n % 2) == 0)
        {
            return false;
        }
        if (n < 9)
        {
            return true;
        }
        if ((n % 3) == 0)
        {
            return false;
        }

        int r = n;
        int f = 5;
        while ((f * f) <= r)
        {
            if ((n % f) == 0)
            {
                return false;
            }
            if ((n % (f + 2)) == 0)
            {
                return false;
            }
            f += 6;
        }
        return true;
    }

    static void Main()
    {
        int a = 37;
        bool prime = IsPrime(a);
    }
}
