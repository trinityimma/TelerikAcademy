using System;

class Program
{
    static void Swap(int[] arr, int i, int j)
    {
        if (i == j) return;
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        // Exercise 7
        for (int i = 0; i < arr.Length; i++)
        {
            int min = i;

            for (int j = i + 1; j < arr.Length; j++) if (arr[j] < arr[min]) min = j;
            Swap(arr, i, min);
        }

        // Exercise 4
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

        Console.WriteLine(arr[maxIndex] + " " + maxLength);
    }
}
