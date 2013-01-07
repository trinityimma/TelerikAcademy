using System;

class Program
{
    static void Main()
    {
        int[] arr = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
        int x = 34;

        for (int l = 0, r = arr.Length - 1; l <= r;)
        {
            int m = l + (r - l) / 2;

            if (arr[m] < x) l = m + 1;
            else if (arr[m] > x) r = m - 1;
            else
            {
                Console.WriteLine(m);
                return;
            }
        }
    }
}
