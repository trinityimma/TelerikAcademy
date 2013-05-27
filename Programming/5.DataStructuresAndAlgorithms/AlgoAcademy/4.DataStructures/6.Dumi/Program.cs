using System;
using System.Linq;
using System.Text.RegularExpressions;

static class Program
{
    static bool[] GetWordData(string word)
    {
        bool[] result = new bool[26];

        for (int i = 0; i < word.Length; i++)
            result[word[i] - 'a'] = true;

        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        var input = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Regex.Split(Console.ReadLine().ToLower(), @"[^a-z]+"))
            .SelectMany(x => x)
            .Distinct()
            .ToArray();

        var words = input.Select(word => GetWordData(word)).ToArray();

        Console.WriteLine(string.Join(Environment.NewLine,
            Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(_ => Console.ReadLine())
                .Select(line =>
                {
                    var currentWord = GetWordData(line.ToLower());

                    var matched = words.Where(word =>
                    {
                        for (int i = 0; i < 26; i++)
                            if (currentWord[i] && !word[i])
                                return false;

                        return true;
                    });

                    return string.Format("{0} -> {1}", line, matched.Count());
                })
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date); // 00:00:00.4050565 vs 00:00:65.4732165 w/ dict
#endif
    }
}
