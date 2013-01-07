using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < arr.Length; i++) arr[i] = int.Parse(Console.ReadLine());

        foreach (int item in arr) Console.WriteLine(int.Parse(Console.ReadLine()).CompareTo(item));
    }
}
