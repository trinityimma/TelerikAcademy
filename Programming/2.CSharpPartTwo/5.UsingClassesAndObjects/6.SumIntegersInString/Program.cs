using System;

class Program
{
    static int Sum(string input)
    {
        int value = 0;

        // Read right to left
        for (int i = input.Length, power = 1; i >= 0; i--)
        {
            if (i == input.Length || input[i] == ' ') power = 1;

            else
            {
                value += power * (input[i] - '0');

                power *= 10;
            }
        }

        return value;
    }

    static void Main()
    {
        Console.WriteLine(Sum("43 68 9 23 318"));
    }
}
