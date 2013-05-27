using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

static class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        var words = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Regex.Split(Console.ReadLine().ToLower(), @"[^a-z]+"))
            .SelectMany(x => x);

        var dict = Enumerable.Range('a', 'z').ToDictionary(i => i, _ => new HashSet<string>());

        foreach (string word in words)
            foreach (char letter in word)
                dict[letter].Add(word);

        Console.WriteLine(string.Join(Environment.NewLine,
            Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(_ => Console.ReadLine())
                .Select(line =>
                {
                    var uniqueChars = line.ToLower().ToCharArray().Distinct();

                    var matched = new HashSet<string>(dict[uniqueChars.First()]);

                    foreach (char c in uniqueChars.Skip(1))
                        matched.IntersectWith(dict[c]);

                    return string.Format("{0} -> {1}", line, matched.Count());
                })
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
