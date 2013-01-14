using System;

class Program
{
    static void Main()
    {
        int[] n = { 10, 5 , 0};
        int sign = 1;

        foreach (int x in n) sign *= x < 0 ? -1 : x > 0 ? 1 : 0;
    }
}
