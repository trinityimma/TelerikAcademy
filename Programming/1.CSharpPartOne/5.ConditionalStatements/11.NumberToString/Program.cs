using System;

class Program
{
    static string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    static string[] tens = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

    static string NumberToString(int n)
    {
        string r = "";

        if (n > 99)
        {
            r += ones[n / 100] + " hundred";
            n %= 100;

            if (n != 0) r += " and "; // 101-199 201-299 ... 901-999
            else return r; // 100 200 ... 900
        }

        if (n > 19)
        {
            r += tens[n / 10 - 2];
            n %= 10;

            if (n != 0) r += "-"; // 21-29  31-39 ... 91-99
            else return r; // 20 30 ... 90
        }

        r += ones[n]; // 1 2 ... 19
        return r;
    }

    static void Main()
    {
        int[] n = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 };

        foreach (int i in n) Console.WriteLine(i + ": " + NumberToString(i));
    }
}
