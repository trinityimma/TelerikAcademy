using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static string message;
    static List<string> decodedMessages = new List<string>();
    static Dictionary<string, string> ciphers = new Dictionary<string, string>();

    static void Input()
    {
        message = Console.ReadLine();

        foreach (Match cipher in Regex.Matches(Console.ReadLine(), @"(\D)(\d+)"))
            ciphers[cipher.Groups[1].Value] = cipher.Groups[2].Value;
    }

    static void Decode(string encoded, string decoded)
    {
        if (encoded.Length == 0)
            decodedMessages.Add(decoded);

        else foreach (var cipher in ciphers)
            if (encoded.StartsWith(cipher.Value))
                Decode(encoded.Substring(cipher.Value.Length), decoded + cipher.Key);
    }

    static void Output()
    {
        Console.WriteLine(decodedMessages.Count);

        foreach (string msg in decodedMessages)
            Console.WriteLine(msg);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        Input();

        Decode(message, String.Empty);

        decodedMessages.Sort();

        Output();
    }
}
