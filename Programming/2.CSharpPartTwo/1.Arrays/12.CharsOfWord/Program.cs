using System;

class Program
{
    static void Main()
    {
        char[] arr = new char['z' - 'a' + 1];
        for (int i = 0; i < arr.Length; i++) arr[i] = (char)('a' + i);

        string s = Console.ReadLine();
        foreach (char c in s) Console.WriteLine(c - 'a');
    }
}
