using System;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 3, 2, 3, 2, 3, 4, 3, 3, 2 };

        int count = 0, majorityElement = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (count == 0)
                majorityElement = arr[i];

            if (arr[i] == majorityElement)
                count++;
            else
                count--;
        }

        count = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == majorityElement)
                count++;

        if (count > arr.Length / 2)
            Console.WriteLine(majorityElement);
        else
            Console.WriteLine(-1);
    }
}
