using System;
using System.Linq;
using System.Text.RegularExpressions;

internal class Program
{
    static string searched = null;
    static int[][] wordsData = null;
    static string[] wordsInput = null;

    static int price = 0;
    static int minPrice = int.MaxValue;
    private static bool[,] visited;

    static void Generate(int start)
    {
        if (start == searched.Length)
        {
            if (price < minPrice)
                minPrice = price;

            return;
        }

        if (visited[start, price])
        {
            return;
        }

        visited[start, price] = true;

        for (int i = 0; i < wordsData.Length; i++)
        {
            if (start + wordsInput[i].Length > searched.Length)
                continue;

            if (!IsValid(i, start))
                continue;

            var delta = CalcDifference(i, start);
            price += delta;
            Generate(start + wordsInput[i].Length);
            price -= delta;
        }
    }

    private static bool IsValid(int k, int start)
    {
        var letters = new int[26];

        for (int i = 0; i < wordsInput[k].Length; i++)
            letters[searched[start + i] - 'a']++;

        for (int i = 0; i < 26; i++)
            if (wordsData[k][i] != letters[i])
                return false;

        return true;
    }

    private static int[] GetWordData(string word, int i)
    {
        var letters = new int[26];

        foreach (char c in word)
            letters[c - 'a']++;

        return letters;
    }

    static int CalcDifference(int k, int start)
    {
        int result = 0;

        for (int i = 0; i < wordsInput[k].Length; i++)
            result += wordsInput[k][i] == searched[start + i] ? 0 : 1;

        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        searched = Console.ReadLine();
        Console.ReadLine();
        wordsInput = Regex.Split(Console.ReadLine(), " ").Select(match => match.Replace("\"", "")).ToArray();

        wordsData = wordsInput.Select(GetWordData).ToArray();
        visited = new bool[searched.Length, searched.Length];
        Generate(0);

        Console.WriteLine(minPrice != int.MaxValue ? minPrice : -1);

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}