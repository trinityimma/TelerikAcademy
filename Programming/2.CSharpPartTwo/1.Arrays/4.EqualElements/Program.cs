using System;

class Program
{
    static void Main()
    {
        int[] arr = { 3, 2, 3, 4, 2, 2, 4 };

        int maxLength = 1, maxIndex = 0;
        for (int i = 1, currentLength = 1; i < arr.Length; i++)
        {
            currentLength = arr[i - 1] == arr[i] ? currentLength + 1 : 1;

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                maxIndex = i - currentLength + 1;
            }
        }

        for (int i = 0; i < maxLength; i++) Console.WriteLine(arr[maxIndex + i]);
    }
}
