using System;

class Program
{
    static void Main()
    {
        bool[] arr = new bool[(int)1E7 + 1];

        for (int i = 2; i * i <= arr.Length; i++)
            if (!arr[i])
                for (int j = i * i; j < arr.Length; j += i) arr[j] = true;

        for (int i = 2; i < arr.Length; i++) if (!arr[i]) Console.WriteLine(i);
    }
}
