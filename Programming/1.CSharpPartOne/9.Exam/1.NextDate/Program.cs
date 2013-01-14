using System;

class Program
{
    static int[] monthsLength = { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    static int GetMonthLength(int m, int y)
    {
        if (m == 2)
            if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0) return 29;
            else return 28;

        return monthsLength[m - 1];
    }

    static void Main()
    {
        int d = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        d++;
        if (d > GetMonthLength(m, y))
        {
            d = 1;
            m++;

            if (m > 12)
            {
                m = 1;
                y++;
            }
        }

        Console.WriteLine("{0}.{1}.{2}", d, m, y);
    }
}
