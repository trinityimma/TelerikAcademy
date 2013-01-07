using System;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int maxSum = arr[0], maxLength = 1, maxIndex = 0;
        for (int i = 1, currentSum = arr[0], currentIndex = 0; i < arr.Length; i++)
        {
            currentSum += arr[i];

            if (arr[i] > currentSum)
            {
                currentSum = arr[i];
                currentIndex = i;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxIndex = currentIndex;
                maxLength = i - currentIndex + 1;
            }
        }

        for (int i = 0; i < maxLength; i++) Console.WriteLine(arr[maxIndex + i]);
    }
}
