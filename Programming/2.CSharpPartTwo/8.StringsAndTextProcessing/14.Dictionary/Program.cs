using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] dictionary = {
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET",
            "namespace - hierarchical organization of classes"
        };
        string word = "namespace";

        // TODO: Interpolation search
        foreach (string item in dictionary)
        {
            var fragments = Regex.Split(item, " - ");

            if (fragments[0] == word)
            {
                Console.WriteLine(fragments[1]);
                return;
            }
        }
    }
}
