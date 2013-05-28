using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 2, 3, 4, 2, 2, 4 };

        int maxLength = 1, maxIndex = 0;
        for (int currentIndex = 1, currentLength = 1; currentIndex < numbers.Length; currentIndex++)
        {
            if (numbers[currentIndex] != numbers[currentIndex - 1])
                currentLength = 0;

            currentLength++;

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                maxIndex = currentIndex - currentLength + 1;
            }
        }

        Console.WriteLine(string.Join(" ", numbers.Skip(maxIndex).Take(maxLength)));
    }
}
