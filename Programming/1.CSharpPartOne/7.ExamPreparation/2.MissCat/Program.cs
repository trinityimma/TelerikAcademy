using System;

class Program
{
    static void Main()
    {
        int[] cats = new int[10];

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++) cats[int.Parse(Console.ReadLine()) - 1]++;

        int max = 0;
        for (int i = 1; i < cats.Length; i++) if (cats[i] > cats[max]) max = i;

        Console.WriteLine(max + 1);
    }
}
