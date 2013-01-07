using System;

class Program
{
    static void Main()
    {
        char[] arr1 = { '1', '2', '3' };
        char[] arr2 = { '2', '2', '2' };

        for (int i = 0; i < arr1.Length; i++) Console.WriteLine(arr1[i].CompareTo(arr2[i]));
    }
}
